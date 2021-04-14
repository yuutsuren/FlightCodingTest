using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    public class FlightTestDate
    {
        public static FlightTestDate requestedDate = new FlightTestDate();


    }

    public static class FlightFilter
    {
        // Метод вылета до текущего момента времени
        public static IEnumerable<Flight> GetFlightsBefore(this IEnumerable<Flight> flights, DateTime departureDateTime) 
        {
            IEnumerable<Flight> filteredFlights = flights.Where(x => x.Segments[0].DepartureDate < departureDateTime);

            return filteredFlights;
        }

        
        public static IEnumerable<Flight> GetFlightsArrivalBeforeDeparture(this IEnumerable<Flight> flights)
        {
            IEnumerable<Flight> filteredFlights = flights.Where(x => x.Segments.All(y => y.ArrivalDate < y.DepartureDate));

            return filteredFlights;
        }

        public static IEnumerable<Flight> GetFlightsWithTwoHoursDelay(this IEnumerable<Flight> flights)
        {
            IEnumerable<Flight> filteredFlights = flights.Where(x => x.Segments.Count > 1).Where(x =>
            {
                bool hasTwoHoursDelay = false;

                int iterationCount = x.Segments.Count - 1;

                TimeSpan twoHoursDelay = TimeSpan.FromHours(2);

                for (int i = 0; i < iterationCount; i++)
                {
                    TimeSpan segmentsTimeDifference = x.Segments[i + 1].DepartureDate - x.Segments[i].ArrivalDate;

                    if (segmentsTimeDifference > twoHoursDelay)
                    {
                        hasTwoHoursDelay = true;

                        break;
                    }
                }

                return hasTwoHoursDelay;
            });

            return filteredFlights;
        }
    }
}

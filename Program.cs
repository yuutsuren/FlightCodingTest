using System;
using System.Collections.Generic;
using System.Linq;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("1,2,3");

            FlightBuilder flightBuilder = new FlightBuilder();

            IEnumerable<Flight> testFlights = flightBuilder.GetFlights();

            DateTime departureDateTime = DateTime.Now;
            //DateTime departureDateTime = DateTime.Parse(Console.ReadLine()); // 04/14/2021 18:00:00

            IEnumerable<Flight> flightsBeforeDateTime = testFlights.GetFlightsBefore(departureDateTime);

            Console.WriteLine($"Полёты с датой вылета до {departureDateTime}:");

            flightsBeforeDateTime.WriteToConsole();

            Console.WriteLine(new string('=', 50));

            IEnumerable<Flight> flightsArrivalBeforeDeparture = testFlights.GetFlightsArrivalBeforeDeparture();

            Console.WriteLine("Полёты у которых имеются сегменты с датой вылета позже даты прибытия:");

            flightsArrivalBeforeDeparture.WriteToConsole();

            Console.WriteLine(new string('=', 50));

            IEnumerable<Flight> flightsWithToHoursDelay = testFlights.GetFlightsWithTwoHoursDelay();

            Console.WriteLine("Полёты у которых время ожидания между перелётами более 2-х часов:");

            flightsWithToHoursDelay.WriteToConsole();

        }
    }
}

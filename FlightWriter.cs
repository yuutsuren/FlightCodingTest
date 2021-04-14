using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Gridnine.FlightCodingTest
{
    public static class FlightWriter
    {
       public static void WriteToConsole(this IEnumerable<Flight> flights)
        {
            int elementNumber = 1;

            foreach (Flight flight in flights)
            {
                string flightJson = JsonSerializer.Serialize(flight, new JsonSerializerOptions() { WriteIndented = true });
                Console.WriteLine($"Element: {elementNumber}");
                Console.WriteLine(flightJson);
                
                elementNumber++;
            }
        }
    }
}

using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";


        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------
            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            ITrackable location1 = null;
            ITrackable location2 = null;

            // Create a `double` variable to store the distance
            double distance = 0.0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`  (using system)
            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`) (line 31) // 

            for (int a = 0; a < locations.Length; a++)  // Pat used int i for both for loops
            {
                var locA = locations[a];                                                             // var locA = locations[a];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);     // Create a new corA Coordinate with your locA's lat and long     

                for (int b = 0; b < locations.Length; b++)           // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                {
                    var locB = locations[b];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);   // Create a new Coordinate with your locB's lat and long                                                                  
                    var length = corA.GetDistanceTo(corB);          // Now, compare the two using `.GetDistanceTo()`, which returns a double   

                    if (length > distance)                          // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    {
                        distance = length;
                        location1 = locA;
                        location2 = locB;
                    }

                }
                
            }

            var distanceMiles = Math.Round(distance * 0.000621371, 2);   //  (distance * conversts to mile, # how many decimal places)
            Console.WriteLine($"{location1.Name} and {location2.Name} are {distanceMiles} miles apart.");

            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

        }
    }
}


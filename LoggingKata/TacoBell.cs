using System;
using System.Collections.Generic;
using System.Text;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public TacoBell(string name, Point location)
        {
            Name = name;
            Location = location;
        }
    }
}
   

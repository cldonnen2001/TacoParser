﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public interface ITrackable
    {
       public string Name { get; set; }
       public Point Location { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlotSimulator
{
    public class LinePrize
    {
        public int LineId { get; set; }
        public int CardId { get; set; }
        public int Streak { get; set; }
        public int Multiplier { get; set; }
    }
}

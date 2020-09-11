using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlotSimulator
{
    public class Line
    {
        public int Id { get; set; }
        public int[] Outcome { get; set; }
        public int[] YPositions { get; set; }
        public string UICoordinates { get; set; }
    }
}

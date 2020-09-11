using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlotSimulator
{
    public class SpinOutcome
    {
        public int TotalWinnings { get; set; }
        public List<GameReel> Reels { get; set; }
        public List<LinePrize> LineWinnings { get; set; }
        public List<Line> WinningLines { get; set; }
    }
}

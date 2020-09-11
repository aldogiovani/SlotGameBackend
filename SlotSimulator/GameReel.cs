using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlotSimulator
{
    public class GameReel
    {
        public int Id { get; set; }
        public List<GameReelPosition> Positions { get; set; }
    }
}

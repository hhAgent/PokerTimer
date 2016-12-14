using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerTimer.Models
{
    public class BlindsLevel
    {
        public long TournamentId { get; set; }

        public int Stage { get; set; }

        public int Level { get; set; }

        public int SmallBlind { get; set; }

        public int BigBlind { get; set; }

        public int Ante { get; set; }

        public int Length { get; set; }
    }
}
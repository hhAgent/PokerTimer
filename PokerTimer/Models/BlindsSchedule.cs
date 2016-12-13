using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerTimer.Models
{
    public class BlindsSchedule
    {
        public long TournamentId { get; set; }

        public int Stage { get; set; }

        public int Level { get; set; }

        public decimal SmallBlind { get; set; }

        public decimal BigBlind { get; set; }

        public decimal Ante { get; set; }

        public decimal Length { get; set; }
    }
}
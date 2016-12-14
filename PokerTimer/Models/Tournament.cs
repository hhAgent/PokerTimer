using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerTimer.Models
{
    public class Tournament
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Rebuy { get; set; }

        public int StartingChips { get; set; }

        public int Addon { get; set; }

        public int TotalPlayers { get; set; }

        public int CurrentPlayers { get; set; }

        public decimal PrizePool { get; set; }

        public decimal AvgStack { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime StartingTime { get; set; }

        public int LastStageTime { get; set; }

        public int LastStage { get; set; }

        public bool IsStopped { get; set; }
    }
}
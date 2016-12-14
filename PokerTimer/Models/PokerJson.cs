using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerTimer.Models
{
    public class PokerJson
    {
        public string TournamentName { get; set; }

        public DateTime ServerTime { get; set; }

        public int CurrentPlayers { get; set; }

        public int TotalPlayers { get; set; }

        public int CurrentSmallBlind { get; set; }

        public int CurrentBigBlind { get; set; }

        public int CurrentAnte { get; set; }

        public int NextSmallBlind { get; set; }

        public int NextBigBlind { get; set; }

        public int Rebuy { get; set; }

        public int Addon { get; set; }

        public int CurrentStage { get; set; }

        public int CurrentLevel { get; set; }

        public int CurrentCountDown { get; set; }

        public decimal AvgStack { get; set; }

        public decimal PrizePool { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
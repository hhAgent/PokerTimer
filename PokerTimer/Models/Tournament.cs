using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerTimer.Models
{
    public class Tournament
    {
        /// <summary>
        /// Database tự sinh, không cần quản lý
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Hiển thị trong các trang Add / Edit General tournament
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hiển thị trong các trang Add / Edit General tournament
        /// </summary>
        public int Rebuy { get; set; }

        /// <summary>
        /// Hiển thị trong các trang Add / Edit General tournament
        /// </summary>
        public int StartingChips { get; set; }

        /// <summary>
        /// Hiển thị trong các trang Add / Edit General tournament
        /// </summary>
        public int Addon { get; set; }

        /// <summary>
        /// Hiển thị trong các trang Add / Edit Clock tournament
        /// </summary>
        public DateTime StartingTime { get; set; }

        /// <summary>
        /// Hiển thị trong trang Edit Clock tournament
        /// </summary>
        public int LastStageTime { get; set; }

        /// <summary>
        /// Hiển thị trong trang Edit Clock tournament
        /// </summary>
        public int LastStage { get; set; }

        /// <summary>
        /// Cứ mỗi lần tương tác add/edit gì tournament thì gán nó là = DateTime.Now
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Hiển thị trong trang Edit Clock Tournament
        /// </summary>
        public bool IsStopped { get; set; }

        /// <summary>
        /// Hiển thị trong trang Edit General Tournament
        /// </summary>
        public int TotalPlayers { get; set; }

        /// <summary>
        /// Hiển thị trong trang Edit General Tournament
        /// </summary>
        public int CurrentPlayers { get; set; }

        /// <summary>
        /// Hiển thị trong trang Edit General Tournament
        /// </summary>
        public decimal PrizePool { get; set; }

        /// <summary>
        /// Hiển thị trong trang Edit General Tournament
        /// </summary>
        public decimal AvgStack { get; set; }

    }
}
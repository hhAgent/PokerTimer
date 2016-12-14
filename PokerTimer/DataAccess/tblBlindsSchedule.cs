using PokerTimer.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace PokerTimer.DataAccess
{
    public class tblBlindsSchedule : SQLiteConnector
    {
        public static List<BlindsLevel> GetBlindsLevelByTournamentId(long tourId)
        {
            try
            {
                string sql = string.Format("SELECT * FROM blindschedule WHERE tournamentid={0} ORDER BY stage", tourId);

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                List<BlindsLevel> res = new List<BlindsLevel>();
                while (reader.Read())
                {
                    res.Add(new BlindsLevel()
                    {
                        TournamentId = long.Parse(reader["id"].ToString()),
                        Stage = int.Parse(reader["stage"].ToString()),
                        Level = int.Parse(reader["level"].ToString()),
                        Length = int.Parse(reader["length"].ToString()),
                        SmallBlind = int.Parse(reader["smallblind"].ToString()),
                        BigBlind = int.Parse(reader["bigblind"].ToString()),
                        Ante = int.Parse(reader["ante"].ToString()),
                    });
                }
                return res;
            }
            catch
            {
                return new List<BlindsLevel>();
            }
        }

        public static int DeleteByTournamentId(long tourId)
        {
            try
            {
                string sql = string.Format("DELETE FROM blindschedule WHERE tournamentid={0}", tourId);

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static void Add(BlindsLevel level)
        {
            try
            {
                long id = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));

                string sql = @"INSERT INTO blindschedule ( tournamentid, 
                                                           level, 
                                                           stage,
                                                           length,
                                                           smallblind,
                                                           bigblind,
                                                           ante                                                       
                                                        )
                               values(
                                    @tournamentid,
                                    @level, 
                                    @stage,
                                    @length,
                                    @smallblind,
                                    @bigblind,
                                    @ante                                    
                               )";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                                
                command.Parameters.AddWithValue("@tournamentid", level.TournamentId);
                command.Parameters.AddWithValue("@level", level.Level);
                command.Parameters.AddWithValue("@stage", level.Stage);
                command.Parameters.AddWithValue("@length", level.Length);
                command.Parameters.AddWithValue("@smallblind", level.SmallBlind);
                command.Parameters.AddWithValue("@bigblind", level.BigBlind);
                command.Parameters.AddWithValue("@ante", level.Ante);

                command.ExecuteNonQuery();
            }
            catch
            {
            }
        }
    }
}

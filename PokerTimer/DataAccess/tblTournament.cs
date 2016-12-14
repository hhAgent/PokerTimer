using PokerTimer.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PokerTimer.DataAccess
{
    public class tblTournament : SQLiteConnector
    {
        public static List<Tournament> GetAllTournament()
        {
            return GetTournamentById(-1);
        }

        public static List<Tournament> GetTournamentById(long id = -1)
        {
            try
            {
                string sql = string.Empty;
                if (id < 0)
                {
                    sql = "SELECT * FROM tournament";
                }
                else
                {
                    sql = "SELECT * FROM tournament where id=" + id;
                }

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                List<Tournament> res = new List<Tournament>();
                while (reader.Read())
                {
                    res.Add(new Tournament()
                    {
                        Name = reader["name"].ToString(),
                        Id = long.Parse(reader["id"].ToString()),
                        StartingTime = DateTime.ParseExact(reader["starttime"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                        Rebuy = int.Parse(reader["rebuy"].ToString()),
                        Addon = int.Parse(reader["addon"].ToString()),
                        UpdateTime = DateTime.ParseExact(reader["updatetime"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                        TotalPlayers = int.Parse( reader["totalplayers"].ToString() ),
                        CurrentPlayers = int.Parse(reader["currentplayers"].ToString() ),
                        PrizePool = decimal.Parse( reader["prizepool"].ToString() ),
                        AvgStack = decimal.Parse( reader["avgstack"].ToString() ),
                        LastStage = int.Parse( reader["laststage"].ToString() ),
                        LastStageTime = int.Parse( reader["laststagetime"].ToString() )
                    });
                }
                return res;
            }
            catch
            {
                return new List<Tournament>();
            }
        }

        public static int DeleteTournamentById(long tourId)
        {
            try
            {
                string sql = string.Format("DELETE FROM tournament WHERE id={0}", tourId);

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }
    }
}
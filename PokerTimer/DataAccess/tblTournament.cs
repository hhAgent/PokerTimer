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
            return GetListTournament(-1);
        }

        public static Tournament GetTournamentById(long id)
        {
            var res = GetListTournament(id);
            if (res.Count == 0)
                return null;
            return res[0];
        }

        private static List<Tournament> GetListTournament(long id = -1)
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
                    sql = "SELECT * FROM tournament where id=@id";
                }

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                if (id >= 0)
                {
                    command.Parameters.AddWithValue("@id", id);
                }

                SQLiteDataReader reader = command.ExecuteReader();

                List<Tournament> res = new List<Tournament>();
                while (reader.Read())
                {
                    res.Add(new Tournament()
                    {
                        // General Info
                        Id = long.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString(),                        
                        Rebuy = int.Parse(reader["rebuy"].ToString()),
                        Addon = int.Parse(reader["addon"].ToString()),
                        StartingChips = int.Parse( reader["startingchips"].ToString() ),                        
                        TotalPlayers = int.Parse( reader["totalplayers"].ToString() ),
                        CurrentPlayers = int.Parse(reader["currentplayers"].ToString() ),
                        PrizePool = decimal.Parse( reader["prizepool"].ToString() ),
                        AvgStack = decimal.Parse( reader["avgstack"].ToString() ),

                        // Time info
                        IsStopped = bool.Parse(reader["isstopped"].ToString()),
                        StartingTime = DateTime.ParseExact(reader["starttime"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                        UpdateTime = DateTime.ParseExact(reader["updatetime"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
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
                string sql = string.Format("DELETE FROM tournament WHERE id=@id");
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@id", tourId);
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int UpdateTournamentGeneralInfo(Tournament tour)
        {
            try
            {
                string sql = @"UPDATE tournament 
                               SET name=@name,
                                   totalplayers=@totalplayers,
                                   currentplayers=@currentplayers,
                                   prizepool=@prizepool,
                                   avgstack=@avgstack,
                                   rebuy=@rebuy,
                                   addon=@addon,
                                   startingchips=@startingchips
                               WHERE id=@id";                             

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@name", tour.Name);
                command.Parameters.AddWithValue("@totalplayers", tour.TotalPlayers);
                command.Parameters.AddWithValue("@currentplayers", tour.CurrentPlayers);
                command.Parameters.AddWithValue("@prizepool", tour.PrizePool);
                command.Parameters.AddWithValue("@avgstack", tour.AvgStack);
                command.Parameters.AddWithValue("@rebuy", tour.Rebuy);
                command.Parameters.AddWithValue("@addon", tour.Addon);
                command.Parameters.AddWithValue("@startingchips", tour.StartingChips);
                command.Parameters.AddWithValue("@id", tour.Id);

                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static int UpdateTournamentTime(Tournament tour)
        {
            try
            {
                string sql = @"UPDATE tournament 
                               SET laststage=@laststage,
                                   laststagetime=@laststagetime,
                                   starttime=@starttime,
                                   isstopped=@isstopped
                               WHERE id=@id";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@laststage", tour.LastStage);
                command.Parameters.AddWithValue("@laststagetime", tour.LastStageTime);
                command.Parameters.AddWithValue("@starttime", tour.StartingTime);
                command.Parameters.AddWithValue("@isstopped", tour.IsStopped);
                command.Parameters.AddWithValue("@id", tour.Id);

                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public static long Add(Tournament tour)
        {
            try
            {
                long id = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));

                string sql = @"INSERT INTO tournament (id, 
                                                       name, 
                                                       starttime,
                                                       rebuy,
                                                       addon,
                                                       updatetime,
                                                       totalplayers,
                                                       currentplayers,
                                                       prizepool,
                                                       avgstack,
                                                       startingchips,                                            
                                                       laststage,
                                                       laststagetime,
                                                       isstopped
                                                        )
                               values(
                                    @id,
                                    @name, 
                                    @starttime,
                                    @rebuy,
                                    @addon,
                                    @updatetime,
                                    @totalplayers,
                                    @currentplayers,
                                    @prizepool,
                                    @avgstack,
                                    @startingchips,                                            
                                    @laststage,
                                    @laststagetime,
                                    @isstopped
                               )";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                // General Info
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", tour.Name);                
                command.Parameters.AddWithValue("@rebuy", tour.Rebuy);
                command.Parameters.AddWithValue("@addon", tour.Addon);
                command.Parameters.AddWithValue("@updatetime", tour.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss") );
                command.Parameters.AddWithValue("@totalplayers", tour.TotalPlayers);
                command.Parameters.AddWithValue("@currentplayers", tour.CurrentPlayers);
                command.Parameters.AddWithValue("@prizepool", tour.PrizePool);
                command.Parameters.AddWithValue("@avgstack", tour.AvgStack);
                command.Parameters.AddWithValue("@startingchips", tour.StartingChips);
                
                // Time
                command.Parameters.AddWithValue("@starttime", tour.StartingTime.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@laststage", tour.LastStage);
                command.Parameters.AddWithValue("@laststagetime", tour.LastStageTime);
                command.Parameters.AddWithValue("@isstopped", tour.IsStopped);
                command.ExecuteNonQuery();

                return id;
            }
            catch
            {
                return -1;
            }
        }
    }
}
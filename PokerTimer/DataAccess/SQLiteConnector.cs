using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace PokerTimer.DataAccess
{
    public class SQLiteConnector
    {
        protected static SQLiteConnection m_dbConnection;
        public static void Init()
        {
            string databasePath = Directory.GetCurrentDirectory() + "\\Data\\poker.db3";
            m_dbConnection = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", databasePath)
                );
            m_dbConnection.Open();
        }

        public static string TestConnection()
        {
            try
            {
                string sql = "SELECT * FROM sqlite_master WHERE type='table';";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["name"] != null)
                    {
                        reader.Close();
                        return string.Empty;
                    }
                }
                return "DB Empty";
            }
            catch (Exception ex)
            {
                return ex.Message + " " + Environment.NewLine + ex.StackTrace;
            }
        }

        public static void Close()
        {
            m_dbConnection.Close();
        }
    }
}
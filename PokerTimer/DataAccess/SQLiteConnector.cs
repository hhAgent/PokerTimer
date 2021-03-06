﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace PokerTimer.DataAccess
{
    public class SQLiteConnector
    {
        protected static SQLiteConnection m_dbConnection = null;
        public static void Init()
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            m_dbConnection = new SQLiteConnection(connectionString);                
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
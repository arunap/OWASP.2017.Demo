﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace OWASP.Top10.Helpers
{
    public static class DbHelper
    {
        // private const string connectionString = "Server=localhost;Database=sakila;Uid=sakila_admin_user;Pwd=Pa$$w0rd; Connection Timeout=30";
        private static  string connectionString = ConfigurationManager.AppSettings["DbConenction"].ToString();

        public static DataTable ExecuteSelectCommand(string command)
        {
            var ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command, connection))
                {
                    dataAdapter.Fill(ds);
                }
            }
            return ds.Tables[0];
        }

        public static void ExecuteInsertCommand(string command)
        {
            var ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                MySqlCommand mySqlCommand = new MySqlCommand(command, connection);
                mySqlCommand.ExecuteNonQuery();
                
            }
        }
    }
}
﻿using Microsoft.Data.Sqlite;

internal class DatabaseManager
{
    internal void CreateTable(string connectionString)
    {
       using(var connection = new SqliteConnection(connectionString))
       {

         using(var tableCmd = connection.CreateCommand())
         {
                connection.Open();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS coding(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Duration TEXT
                )";

                tableCmd.ExecuteNonQuery();               

         }

         using(var tableCmd = connection.CreateCommand())
         {
                connection.Open();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS workout(
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,
                       Date TEXT,
                       Duration TEXT
                    )";

                tableCmd.ExecuteNonQuery();
         }
       }
      
    }
}
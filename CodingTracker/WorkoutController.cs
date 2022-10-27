using Microsoft.Data.Sqlite;
using System.Configuration;
using System.Text;

internal class WorkoutController
{
    string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

   
    internal  void Post(Workout workout)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var tableCmd = connection.CreateCommand())
            {
                connection.Open();
                tableCmd.CommandText = $"INSERT INTO workout (date, duration) VALUES ('{workout.Date}', '{workout.Duration}')";
                tableCmd.ExecuteNonQuery();
            }
        }
    }

    internal void Delete(int id)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var tableCmd = connection.CreateCommand())
            {
                connection.Open();

                tableCmd.CommandText = $"DELETE FROM workout WHERE id = '{id}'";
                tableCmd.ExecuteNonQuery();

                Console.WriteLine($"Record with Id {id} was deleted.");
            }
        }
    }


    internal void Update(Workout workout)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var tableCmd = connection.CreateCommand())
            {
                connection.Open();
                tableCmd.CommandText =
                    $@"UPDATE workout SET 
                          Date = '{workout.Date}', 
                          Duration = '{workout.Duration}' 
                      WHERE       
                         Id = {workout.Id}
                    ";

                tableCmd.ExecuteNonQuery();

            }
        }
        Console.WriteLine($"Record with Id {workout.Id} was updated.");

    }


    internal void Get()
    {
        List<Coding> tableData = new List<Coding>();
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var tableCmd = connection.CreateCommand())
            {
                connection.Open();
                tableCmd.CommandText = $"SELECT * from workout";

                using (var reader = tableCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tableData.Add(
                                new Coding
                                {
                                    Id = reader.GetInt32(0),
                                    Date = reader.GetString(1),
                                    Duration = reader.GetString(2)
                                });
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\n No rows found");
                    }
                }
            }
            Console.WriteLine("\n\n");

        }

        TableVisualisation1.ShowTable(tableData);
    }

    internal Workout GetById(int id)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var tableCmd = connection.CreateCommand())
            {
                connection.Open();
                tableCmd.CommandText = $"SELECT * FROM workout Where Id = '{id}'";

                using (var reader = tableCmd.ExecuteReader())
                {
                    Workout workout = new();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        workout.Id = reader.GetInt32(0);
                        workout.Date = reader.GetString(1);
                        workout.Duration = reader.GetString(2);
                    }

                    Console.WriteLine("\n\n");

                    return workout;
                };
            }
        }
    }

}


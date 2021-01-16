using MySql.Data.MySqlClient;
using Plants.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Plants.Infrastructure.Data
{
    public class DataContext
    {
        public string ConnectionString { get; set; }

        public DataContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public ICollection<Score> GetAllScores()
        {
            ICollection<Score> scores = new List<Score>();

            using MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM SCORES", connection);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                scores.Add(new Score 
                { 
                    Id = Convert.ToInt32(reader["Id"]),
                    TimeStamp = Convert.ToDateTime(reader["TimeStamp"]),
                    Value = Convert.ToInt32(reader["Value"])
                });

            return scores;
        }
    }
}
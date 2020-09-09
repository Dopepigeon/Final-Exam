using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer.Classes
{
    public static class Database
    {
        private static string connectionString = "Server=localhost;Database=infoprojekt;Uid=root;Pwd=";

        public static List<Temperatur> GetTempRange(DateTime start, DateTime end)
        {
            List<Temperatur> tempRange = new List<Temperatur>();
            var connection = OpenConnection();
            try
            {
                string query = "SELECT * FROM temperatur WHERE zeitstempel BETWEEN @start AND @end ORDER BY zeitstempel DESC";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    tempRange.Add(new Temperatur(dataReader.GetDouble("temperatur"), (DateTime)dataReader.GetMySqlDateTime("zeitstempel")));
                }
            }
            catch (Exception) { }
            CloseConnection(connection);
            return tempRange;
        }

        public static void SaveTemp(Temperatur temp)
        {
            var connection = OpenConnection();
            try
            {
                if (connection != null)
                {
                    string query = "INSERT INTO temperatur(temperatur, zeitstempel) VALUES(@temp, @dateTime)";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@temp", temp.temp);
                    cmd.Parameters.AddWithValue("@dateTime", temp.dateTime);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
            CloseConnection(connection);
        }

        public static void GenerateTemp(int amountOfData)
        {
            for (int i = 0; i < amountOfData; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                SaveTemp(new Temperatur(r.Next(0, 31), DateTime.Now.AddSeconds(i+2)));
            }
        }

        private static MySqlConnection OpenConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();
                return mySqlConnection;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void CloseConnection(MySqlConnection mySqlConnection)
        {
            try
            {
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

    }
}

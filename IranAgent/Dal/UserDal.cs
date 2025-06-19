using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Dal
{
    public static class UserDal
    {
        public static void NewUser(string userName)
        {
            string Query = $"INSERT INTO players (user_name) VALUES ('{userName}');";
            MySqlCommand cmd = null;
            try
            {
                Manager.SqlData.OpenConnection();
                cmd = new MySqlCommand(Query, Manager.SqlData.connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
            finally
            {
                Manager.SqlData.CloseConnection();
            }
        }

        public static bool UserNameIsExist(string userName)
        {
            string query = $"SELECT * FROM players WHERE user_name = '{userName}'";
            MySqlCommand cmd = null;
            try
            {
                Manager.SqlData.OpenConnection();
                cmd = new MySqlCommand(query, Manager.SqlData.connection);
                cmd.Parameters.AddWithValue("@userName", userName);
                object result = cmd.ExecuteScalar();
                int count = Convert.ToInt32(result);

                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            finally
            {
                Manager.SqlData.CloseConnection();
            }
        }

        public static int GetPlayerID(string userName)
        {
            string query = "SELECT player_id FROM players WHERE user_name = @username";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                Manager.SqlData.OpenConnection();

                cmd = new MySqlCommand(query, Manager.SqlData.connection);
                cmd.Parameters.AddWithValue("@username", userName);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader.GetInt32("player_id");
                }

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
            finally
            {
                reader?.Close();
                Manager.SqlData.CloseConnection();
            }
        }




    }
}

using IranAgent.Soldier;
using malshinon.db;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Dal
{
    public static class SoldiersDal
    {
        public static void NewSoldier(FootSoldier soldier)
        {
            string Query = $"INSERT INTO soldiers (name, weaknesses, type) VALUES ('{soldier.Name}','{string.Join(",", soldier.Weaknesses)}', '{soldier.Type}');";
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

        public static List<FootSoldier> ReadAllSoldiers()
        {
            List<FootSoldier> SoldiersList = new List<FootSoldier>();
            string Query = "SELECT * FROM soldiers";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                Manager.SqlData.OpenConnection();
                cmd = new MySqlCommand(Query, Manager.SqlData.connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32("soldier_id");
                    string Name = reader.GetString("name");
                    List<string> Weaknesses = reader.GetString("weaknesses").Split(',').ToList();
                    string Type = reader.GetString("type");

                    if (Type == "foot soldier")
                        SoldiersList.Add(new FootSoldier(Weaknesses, Name, Id));
                    else if(Type == "squad leader")
                        SoldiersList.Add(new SquadLeader(Weaknesses, Name, Id));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Manager.SqlData.CloseConnection();
            }

            return SoldiersList;
        }



    }
}

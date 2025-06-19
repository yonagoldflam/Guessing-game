using IranAgent.RoundsGame;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranAgent.Dal
{
    public static class GameRoundDal
    {
        public static void InsertRound(Round round)
        {
            string Query = $"INSERT INTO game_rounds (player_id, soldier_id, start_time,wrong_attempts) VALUES ({round.PlayerId},{round.SoldierId}, '{round.StartTime}', {round.WrongAttemps});";
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
    }
}

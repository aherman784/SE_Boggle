using BoggleAPI.Source.IAccessorRepository;
using BoggleAPI.Source.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BoggleAPI.Source.AccessorRepository
{
    public class PlayerAccessor : IPlayerAccessor
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void AddPlayers(Player[] players)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            foreach (Player player in players)
            {
                string values = $"({player.Id}, '{player.Username}', {player.Score})";
                string query = $"INSERT INTO players (Id, Username, Score) VALUES {values};";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void DeletePlayers()
        {
            string query = $"DELETE FROM players WHERE true;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public Player[] GetPlayers()
        {
            string query = $"SELECT * FROM players;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            List<Player> playersList = new List<Player>();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Player player = new Player();
                    player.Id = (int)reader["Id"];
                    player.Username = (string)reader["Username"];
                    player.Score = (int)reader["Score"];
                    playersList.Add(player);
                }

                conn.Close();
            }
            return playersList.ToArray();
        }
    }
}

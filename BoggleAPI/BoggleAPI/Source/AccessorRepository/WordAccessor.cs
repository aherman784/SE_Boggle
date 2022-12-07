using BoggleAPI.Source.IAccessorRepository;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace BoggleAPI.Source.AccessorRepository
{
    public class WordAccessor : IWordAccessor
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void PostCorrectWord(string wordGuessed, int playerId)
        {
            string query = $"INSERT INTO correctwords (Word, PlayerId) VALUES ('{wordGuessed}', {playerId});";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public bool IsWordInDictionary(string word)
        {
            return false;
        }

        public void DeleteWords()
        {
            string query = $"DELETE FROM correctwords WHERE true;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}

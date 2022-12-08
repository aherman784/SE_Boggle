using BoggleAPI.Source.IAccessorRepository;
using MySql.Data.MySqlClient;


namespace BoggleAPI.Source.AccessorRepository
{
    public class WordAccessor : IWordAccessor
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void PostCorrectWord(string wordGuessed, int playerId)
        {
            string query = $"INSERT INTO correctwords (Word, PlayerId) VALUES ('{wordGuessed}', {playerId});";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public bool IsWordInDictionary(string word)
        {
            Boolean isWordPresent = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = $"SELECT DISTINCT word FROM dictionary WHERE (word) LIKE '{word}'";
                conn.Open();
                using(MySqlCommand command = new MySqlCommand(query,conn))
                {
                    if (command.ExecuteScalar() != null)
                    {
                        isWordPresent = true;
                    }
                }
                conn.Close();
            }

            return isWordPresent;
        }

        public void DeleteWords()
        {
            string query = $"DELETE FROM correctwords WHERE true;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}

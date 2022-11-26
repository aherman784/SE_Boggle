using BoggleAPI.Source.IAccessorRepository;
using BoggleAPI.Source.Models;

namespace BoggleAPI.Source.AccessorRepository
{
    public class PlayerAccessor : IPlayerAccessor
    {
        public void AddPlayers(Player[] players)
        {
            // Use connection string to add array of players
        }

        public void DeletePlayers()
        {
            // Delete all entries in player table for new game
        }

        public Player[] GetPlayers()
        {
            // Get all players from players table
            Player[] players = new Player[5];
            return players;
        }
    }
}

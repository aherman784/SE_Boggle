using BoggleAPI.Source.IAccessorRepository;

namespace BoggleAPI.Source.AccessorRepository
{
    public class BoardAccessor : IBoardAccessor
    {
        public string[,] GetBoard()
        {
            // Will eventually get the board from the database
            // For now it just returns a random board
            ShuffleEngine shuffleEngine = new ShuffleEngine();
            return shuffleEngine.GetBoard();
        }

        public void SetBoard(string[,] board)
        {
            // Will eventually set the board in the database using the board given
        }
    }
}

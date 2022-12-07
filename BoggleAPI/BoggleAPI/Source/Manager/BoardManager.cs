using BoggleAPI.Source.AccessorRepository;
using BoggleAPI.Source.IManager;

namespace BoggleAPI.Source.Manager
{
    public class BoardManager : IBoardManager
    {
        public string[,] GetBoard(Boolean newGame)
        {
            if (newGame)
            {
                ShuffleEngine shuffleEngine = new ShuffleEngine();
                shuffleEngine.SetNewBoard();
            }

            BoardAccessor boardAccessor = new BoardAccessor();
            String[,] board = boardAccessor.GetBoard();

            return board;
        }
    }
}

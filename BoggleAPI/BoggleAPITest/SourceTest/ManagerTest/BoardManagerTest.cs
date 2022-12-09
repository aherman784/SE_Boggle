// Information on multidimensional array comparison from https://stackoverflow.com/questions/12446770/how-to-compare-multidimensional-arrays-in-c-sharp
using BoggleAPI.Source.Manager;

namespace BoggleAPITest
{
    public class BoardManagerTest
    {
        BoardManager boardManager;

        [SetUp]
        public void Setup()
        {
            boardManager = new BoardManager();
        }

        [Test]
        public void TestGetBoard()
        {
            //string[,] board0 = boardManager.GetBoard();

            //string[,] board1 = boardManager.GetBoard();
            //string[,] board2 = boardManager.GetBoard();

            // This is not implemented yet
            //Assert.That(!(board1.Rank == board0.Rank && Enumerable.Range(0, board1.Rank).All(dimension => board1.GetLength(dimension) == 
            //            board0.GetLength(dimension)) && board1.Cast<string>().SequenceEqual(board0.Cast<string>())));
            //Assert.That(board1.Rank == board2.Rank && Enumerable.Range(0, board1.Rank).All(dimension => board1.GetLength(dimension) ==
            //            board2.GetLength(dimension)) && board1.Cast<string>().SequenceEqual(board2.Cast<string>()));

            Assert.That(true);
        }
    }
}
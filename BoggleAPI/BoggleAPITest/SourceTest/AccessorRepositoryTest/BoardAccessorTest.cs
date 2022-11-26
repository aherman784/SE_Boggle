using BoggleAPI.Source.AccessorRepository;

namespace BoggleAPITest
{
    public class BoardAccessorTest
    {
        BoardAccessor boardAccessor;

        [SetUp]
        public void Setup()
        {
            boardAccessor = new BoardAccessor();
        }

        [Test]
        public void testGetBoard()
        {
            String[,] board = boardAccessor.GetBoard();

            Assert.NotNull(board);
            Assert.NotNull(board[0, 0]);
            Assert.NotNull(board[1, 1]);
            Assert.NotNull(board[2, 2]);
            Assert.NotNull(board[3, 3]);
            Assert.That(16, Is.EqualTo(board.Length));
        }
    }
}
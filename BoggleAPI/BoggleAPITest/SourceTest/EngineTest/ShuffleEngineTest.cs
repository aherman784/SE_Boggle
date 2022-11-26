namespace BoggleAPITest
{
    public class ShuffleEngineTest
    {
        BoggleAPI.ShuffleEngine engine;

        [SetUp]
        public void Setup()
        {
            engine = new BoggleAPI.ShuffleEngine();
        }

        [Test]
        public void testGetBoard()
        {
            String[,] board = engine.GetBoard();

            Assert.NotNull(board);
            Assert.NotNull(board[0, 0]);
            Assert.NotNull(board[1, 1]);
            Assert.NotNull(board[2, 2]);
            Assert.NotNull(board[3, 3]);
            Assert.That(16, Is.EqualTo(board.Length));
        }
    }
}
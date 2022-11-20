namespace BoggleAPITest
{
    public class EngineTest
    {
        BoggleAPI.Engine engine;

        [SetUp]
        public void Setup()
        {
            engine = new BoggleAPI.Engine();
        }

        [Test]
        public void testShuffle()
        {
            String[,] board = engine.shuffle();

            Assert.NotNull(board);
            Assert.NotNull(board[0, 0]);
            Assert.NotNull(board[1, 1]);
            Assert.NotNull(board[2, 2]);
            Assert.NotNull(board[3, 3]);            
        }
    }
}
namespace BoggleAPITest
{
    public class DiceTest
    {
        BoggleAPI.Dice dice;
        [SetUp]
        public void Setup()
        {
            dice = new BoggleAPI.Dice(new String[] { "1", "2", "3", "4", "5", "6"});
        }

        [Test]
        public void testRoll()
        {
            Assert.That(dice.getLetter().GetType() == "1".GetType(), dice.getLetter() + " is not a string, but it should be.");

            dice.roll();

            Assert.That(dice.getLetter().GetType() == "1".GetType(), dice.getLetter() + " is not a string, but it should be.");
        }
    }
}
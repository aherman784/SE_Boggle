

namespace BoggleAPITest.SourceTest.EngineTest
{
    internal class WordValidityEngineTest
    {
        BoggleAPI.WordValidityEngine engine;
        [SetUp]
        public void setup()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            engine = new BoggleAPI.WordValidityEngine();
        }

        [Test]

        public void testWordValidityEngine()
        {



        }
    }
}

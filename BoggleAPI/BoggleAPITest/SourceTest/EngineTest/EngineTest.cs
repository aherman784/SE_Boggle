using BoggleAPI.Source.Engine;

namespace BoggleAPITest
{
    public class EngineTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsWordCorrectLength1()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = true;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("apple");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength2()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = false;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("a");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength3()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = true;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("averylongstringg");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength4()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = false;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("averylongstringgg");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsWordCorrectLength5()
        {
            // Arrange
            var WordEngine = new WordValidityEngine();
            bool expected = true;

            //Act
            bool actual = WordEngine.IsWordCorrectLength("university");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
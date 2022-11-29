using BoggleAPI.Source.AccessorRepository;
using BoggleAPI.Source.Engine;
using BoggleAPI.Source.IManager;

namespace BoggleAPI.Source.Manager
{
    public class WordManager : IWordManager
    {
        public bool GuessWord(string wordGuessed, int playerId)
        {
            var WordValidityEngine = new WordValidityEngine();
            bool isWordValid = WordValidityEngine.IsWordValid(wordGuessed, playerId);
            return isWordValid;
        }

        public void DeleteWords()
        {
            var WordAccessor = new WordAccessor();
            WordAccessor.DeleteWords();
        }
    }
}

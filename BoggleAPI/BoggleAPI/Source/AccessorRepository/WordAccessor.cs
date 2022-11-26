using BoggleAPI.Source.IAccessorRepository;

namespace BoggleAPI.Source.AccessorRepository
{
    public class WordAccessor : IWordAccessor
    {
        public void PostCorrectWord(string wordGuessed, int playerId)
        {
            // Post word to CorrectWords table
        }

        public bool IsWordInDictionary(string word)
        {
            return false;
        }
    }
}

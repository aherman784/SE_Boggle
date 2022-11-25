using BoggleAPI.Source.AccessorRepository;
using BoggleAPI.Source.IEngine;

namespace BoggleAPI.Source.Engine
{
    public class WordValidityEngine : IWordValidityEngine
    {
        public bool IsWordValid(string wordGuessed, int playerId)
        {
            var WordAccessor = new WordAccessor();
            bool isWordInDictionary = WordAccessor.IsWordInDictionary(wordGuessed);
            if (IsWordCorrectLength(wordGuessed) && isWordInDictionary && IsWordOnBoard(wordGuessed))
            {
                WordAccessor.PostCorrectWord(wordGuessed, playerId);
                return true;
            } 
            else
            {
                return false;
            }
        }

        public bool IsWordOnBoard(string wordGuessed)
        {
            return false;
        }
        
        public bool IsWordCorrectLength(string wordGuessed)
        {
            return wordGuessed.Length > 2 && wordGuessed.Length < 17;
        }
    }
}

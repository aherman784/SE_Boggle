using BoggleAPI.Source.Manager;
using BoggleAPI.Source.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoggleAPI.Source.Clients
{
    public class WordClient : Controller
    {
        [HttpPost]
        public bool GuessWord([FromBody] string wordGuessed, int playerId)
        {
            var WordManager = new WordManager();
            return WordManager.GuessWord(wordGuessed, playerId);
        }
    }
}

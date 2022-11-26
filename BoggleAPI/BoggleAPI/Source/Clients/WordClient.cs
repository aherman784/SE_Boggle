using BoggleAPI.Source.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BoggleAPI.Source.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordClient : ControllerBase
    {
        [HttpPost]
        public bool GuessWord([FromBody] string wordGuessed, int playerId)
        {
            var WordManager = new WordManager();
            return WordManager.GuessWord(wordGuessed, playerId);
        }
    }
}

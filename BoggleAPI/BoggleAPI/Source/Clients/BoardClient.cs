using BoggleAPI.Source.Manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoggleAPI.Source.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardClient : ControllerBase
    {
        [HttpGet]
        public String[,] GetBoard(Boolean newGame)
        {
            var BoardManager = new BoardManager();

            // Boolean newGame is true if the game is supposed to restart,
            // and false if it is in the middle of a game.
            return BoardManager.GetBoard(newGame);
        }
    }
}

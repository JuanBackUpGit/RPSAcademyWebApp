using Microsoft.AspNetCore.Mvc;

using RPSAcademyWeb.Models;

namespace RPSAcademyWeb.Controllers
{
    public class PlayController : Controller
    {
        private readonly IGameRepository repo;

        public PlayController(IGameRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChooseOpp(string userName)
        {
            Game game = new Game();
            {
                game.UsersName = userName;
            }
            return View(game);
        }

        public IActionResult SetWinPoint(string userName, string oppName, string oppImage)
        {
            Game game = new Game();
            {
                game.UsersName = userName;
                game.OppName = oppName;
                game.OppImage = oppImage;
            }
            return View(game);
        }

        public IActionResult OppDescription(string userName, string oppImage, string oppName, string oppDescription, string oppStats, List<int> oppDifficulty)
        {
            Game game = new Game();
            {
                game.UsersName = userName;
                game.OppImage = oppImage;
                game.OppName= oppName;
                game.OppDescription = oppDescription;
                game.OppStats = oppStats;
                game.OppDifficulty = oppDifficulty;
            }
            return View(game);
        }
    }
}

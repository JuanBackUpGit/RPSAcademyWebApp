using Microsoft.AspNetCore.Mvc;
using RPSAcademyWeb.Models;
namespace RPSAcademyWeb.Controllers;

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
        public IActionResult SetUp(string userName, Game game)
        {
            game = repo.SetName(userName, game);
            return View(game);
        }
        
        public IActionResult NoviceNancySelected(Game game)
        {
            repo.SetOppNoviceNancy(game);
            return View(game);
        }
    }

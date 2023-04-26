using Microsoft.AspNetCore.Mvc;
using RPSAcademyWeb.Models;

namespace RPSAcademyWeb.Controllers
{
    public class OpponentsInfoController : Controller
    {
        public IActionResult NoviceNancy(Game game)
        {
            return View(game);
        }

        public IActionResult BeginnerBen()
        {
            return View("BeginnerBen");
        }
        public IActionResult JuniorDeveloperJulie()
        {
            return View("JuniorDeveloperJulie");
        }

        public IActionResult IntermediateIsaac()
        {
            return View("IntermediateIsaac");
        }

        public IActionResult AdvancedAmelia()
        {
            return View("AdvancedAmelia");
        }

        public IActionResult SeniorDeveloperSam()
        {
            return View("SeniorDeveloperSam");
        }

        public IActionResult ExpertEthan()
        {
            return View("ExpertEthan");
        }

        public IActionResult MasterfulMorgan()
        {
            return View("MasterfulMorgan");
        }

        public IActionResult GuruGiselle()
        {
            return View("GuruGiselle");
        }

        public IActionResult VisionaryVictor()
        {
            return View("VisionaryVictor");
        }

        public IActionResult LegendaryLila()
        {
            return View("LegendaryLila");
        }

    }
}

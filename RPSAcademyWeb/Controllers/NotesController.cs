using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RPSAcademyWeb.Models;
using System.Diagnostics;
using System.IO;

namespace RPSAcademyWeb.Controllers
{
    public class NotesController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public NotesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public FileResult GetReport()
        {
            var rootPath = _env.WebRootPath;
            var filePath = Path.Combine(rootPath, "Content", "VariablesNotes.pdf");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }


        public FileResult GetReport1()
        {
            var rootPath = _env.WebRootPath;
            var filePath = Path.Combine(rootPath, "Content", "ValueandReferenceTypesNotes.pdf");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }
    }
}

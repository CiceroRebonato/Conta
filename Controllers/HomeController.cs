using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using System.Diagnostics;

namespace ProjetoMVC.Controllers
{
    //[Authorize] // Adicione esta anotação para exigir autenticação em todo o controlador
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Republica()
        {
            return View();
        }

        public IActionResult Pessoas()
        {
            return View();
        }

        public ActionResult BancoImagens()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

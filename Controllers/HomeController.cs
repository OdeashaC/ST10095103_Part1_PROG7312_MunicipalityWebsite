using Microsoft.AspNetCore.Mvc;
using ST10095103_Part1_PROG7312_MunicipalityWebsite.Models;
using System.Diagnostics;

namespace ST10095103_Part1_PROG7312_MunicipalityWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult ReportIssues()
        {
            return View(); 
        }

        public IActionResult Index()
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

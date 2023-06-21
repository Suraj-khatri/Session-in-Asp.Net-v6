using Microsoft.AspNetCore.Mvc;
using Session_V6_.Models;
using System.Diagnostics;

namespace Session_V6_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("Age", 30);
            HttpContext.Session.SetString("Name","Suraj");

            return RedirectToAction("Get");
        }
        public IActionResult Get()
        {
            string Name = HttpContext.Session.GetString("Name");
            int Age = HttpContext.Session.GetInt32("Age").Value;
            ViewBag.Age = Age;
            ViewBag.Name = Name;

            return View();
        }

        public IActionResult Privacy()
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
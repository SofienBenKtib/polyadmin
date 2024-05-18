using BackofficePfa.Data;
using BackofficePfa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BackofficePfa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var students = _dbContext.Students.Count();
            var instructors = _dbContext.Instructors.Count();
            var admins = _dbContext.Administrators.Count();
            return View(new HomeViewModel { Students = students, Instructors = instructors, Admins = admins });
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

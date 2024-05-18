using Microsoft.AspNetCore.Mvc;

namespace BackofficePfa.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

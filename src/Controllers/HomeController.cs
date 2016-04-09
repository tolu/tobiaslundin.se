using Microsoft.AspNet.Mvc;

namespace tobiaslundin.se.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Slides()
        {
            ViewBag.Message = "Slides.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Contact.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}

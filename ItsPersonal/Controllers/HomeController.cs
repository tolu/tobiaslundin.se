using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ItsPersonal.Models;

namespace ItsPersonal.Controllers
{
	public class HomeController : Controller
	{
		private WebRequester webRequester;

		public HomeController()
		{
			webRequester = new WebRequester();
		}

		public ActionResult Index()
		{
			return View();
		}

		[Route("about")]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[Route("slides")]
		public ActionResult Slides()
		{
			ViewBag.Message = "Slides.";

			return View();
		}

		[Route("contact")]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[Route("api/{endpoint}")]
		public async Task<ActionResult> Api(string endpoint)
		{
			var json = await webRequester.GetResponseAsStringAsync(endpoint.Replace("--", "/"));
			return Content(json, "application/json");
		}
	}
}
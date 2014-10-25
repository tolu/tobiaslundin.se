﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItsPersonal.Controllers
{
	public class HomeController : Controller
	{
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
	}
}
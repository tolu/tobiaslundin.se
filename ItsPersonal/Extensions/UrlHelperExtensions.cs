using System;
using System.Web.Mvc;

namespace ItsPersonal.Extensions
{
	public static class UrlHelperExtensions
	{
		public static string Image(this UrlHelper url, string imagePath)
		{
			return url.Content("~/content/images/" + imagePath);
		}

		public static string Html(this UrlHelper url, string htmlPath)
		{
			return url.Content("~/content/html/" + htmlPath);
		}
	}
}
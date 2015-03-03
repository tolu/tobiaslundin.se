using Microsoft.AspNet.Mvc;

namespace source.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string Image(this IUrlHelper url, string imagePath)
        {
            return url.Content("~/img/" + imagePath);
        }
        public static string Html(this IUrlHelper url, string htmlPath)
        {
            return url.Content("~/html/" + htmlPath);
        }
    }
}
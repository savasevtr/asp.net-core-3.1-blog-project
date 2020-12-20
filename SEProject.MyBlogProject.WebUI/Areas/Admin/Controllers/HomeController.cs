using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.WebUI.Filters;

namespace SEProject.MyBlogProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [JwtAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("token");

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
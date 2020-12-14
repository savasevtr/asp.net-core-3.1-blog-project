using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.WebUI.ApiServices.Interfaces;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogApiService _blogApiService;

        public HomeController(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                ViewBag.ActiveCategory = categoryId;

                return View(await _blogApiService.GetAllByCategoryId((int)categoryId));
            }

            return View(await _blogApiService.GetAllAsync());
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            return View(await _blogApiService.GetByIdAsync(id));
        }
    }
}
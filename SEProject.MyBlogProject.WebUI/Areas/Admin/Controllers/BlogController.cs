using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.WebUI.ApiServices.Interfaces;
using SEProject.MyBlogProject.WebUI.Filters;
using SEProject.MyBlogProject.WebUI.Models;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogApiService _blogApiService;

        public BlogController(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            return View(await _blogApiService.GetAllAsync());
        }

        [JwtAuthorize]
        public IActionResult Create()
        {
            return View(new BlogAddModel());
        }

        [JwtAuthorize]
        [HttpPost]
        public async Task<IActionResult> Create(BlogAddModel model)
        {
            if (ModelState.IsValid)
            {
                await _blogApiService.AddAsync(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
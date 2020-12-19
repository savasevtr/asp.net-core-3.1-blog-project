using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.WebUI.ApiServices.Interfaces;
using SEProject.MyBlogProject.WebUI.Filters;
using SEProject.MyBlogProject.WebUI.Models;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [JwtAuthorize]
    public class BlogController : Controller
    {
        private readonly IBlogApiService _blogApiService;

        public BlogController(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blogApiService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View(new BlogAddModel());
        }

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

        public async Task<IActionResult> Update(int id)
        {
            var blogList = await _blogApiService.GetByIdAsync(id);

            return View(new BlogUpdateModel {
                Id = blogList.Id,
                Title = blogList.Title,
                ShortDescription = blogList.ShortDescription,
                Description = blogList.Description
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                await _blogApiService.UpdateAsync(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _blogApiService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.WebUI.ApiServices.Interfaces;
using SEProject.MyBlogProject.WebUI.Filters;
using SEProject.MyBlogProject.WebUI.Models;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [JwtAuthorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryApiService _categoryApiService;

        public CategoryController(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryApiService.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View(new CategoryAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.AddAsync(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var categoryList = await _categoryApiService.GetByIdAsync(id);

            return View(new CategoryUpdateModel
            {
                Id = categoryList.Id,
                Name = categoryList.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.UpdateAsync(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
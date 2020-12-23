using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.Business.Interfaces;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ImagesController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public ImagesController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogImageById(int id)
        {
            var blog = await _blogService.FindByIdAsync(id);

            if (string.IsNullOrWhiteSpace(blog.ImagePath))
            {
                return NotFound("resim yüklenmedi");
            }

            return File($"/img/{blog.ImagePath}", "image/jpeg");
        }
    }
}
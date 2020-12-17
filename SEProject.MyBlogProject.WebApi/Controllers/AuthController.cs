using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.Business.Utilities.JwtTool;
using SEProject.MyBlogProject.DTO.DTOs.AppUserDtos;
using SEProject.MyBlogProject.WebApi.CustomFilters;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;

        public AuthController(IAppUserService appUserService, IJwtService jwtService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SingIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);

            if (user != null)
            {
                return Created("", _jwtService.GenerateJwt(user));
            }

            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);

            return Ok(new AppUserDto { Id = user.Id, Name = user.Name, SurName = user.SurName });
        }
    }
}
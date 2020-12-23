using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.Business.Utilities.FacadeTools;

namespace SEProject.MyBlogProject.WebApi.Controllers
{
    [EnableCors]
    public class ErrorController : ControllerBase
    {
        private readonly IFacade _facade;

        public ErrorController(IFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _facade.CustomLogger.LogError($"\n Hatanın oluştuğu yer: {errorInfo.Path}\n Hata Mesajı: {errorInfo.Error.Message}\n Stack Trace: {errorInfo.Error.StackTrace}\n");

            return Problem(detail: "Bir hata oluştu, en kısa sürede düzeltme yapılacak");
        }
    }
}
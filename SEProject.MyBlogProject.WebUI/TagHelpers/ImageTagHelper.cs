using Microsoft.AspNetCore.Razor.TagHelpers;
using SEProject.MyBlogProject.WebUI.ApiServices.Interfaces;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebUI.TagHelpers
{

    [HtmlTargetElement("getblogimage")]
    public class ImageTagHelper : TagHelper
    {
        private readonly IImageApiService _imageApiService;

        public ImageTagHelper(IImageApiService imageApiService)
        {
            _imageApiService = imageApiService;
        }

        public int Id { get; set; }
        public string ClassName { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var imagePath = await _imageApiService.GetBlogImageByIdAync(Id);

            var html = $"<img src='{imagePath}' class='{ClassName}'>";

            output.Content.SetHtmlContent(html);
        }
    }
}
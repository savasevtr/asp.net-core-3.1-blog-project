using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SEProject.MyBlogProject.WebUI.Models
{
    public class BlogAddModel
    {
        public int AppUserId { get; set; }

        [Required(ErrorMessage = "Başlık alanı gereklidir")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Kısa açıklama alanı gereklidir")]
        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        
        [Display(Name = "Resim")]
        public IFormFile Image { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace SEProject.MyBlogProject.WebUI.Models
{
    public class CategoryAddModel
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace SEProject.MyBlogProject.WebUI.Models
{
    public class CategoryUpdateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
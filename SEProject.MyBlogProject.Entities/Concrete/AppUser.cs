using SEProject.MyBlogProject.Entities.Interfaces;

namespace SEProject.MyBlogProject.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
using SEProject.MyBlogProject.Entities.Interfaces;
using System;

namespace SEProject.MyBlogProject.Entities.Concrete
{
    public class Blog : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
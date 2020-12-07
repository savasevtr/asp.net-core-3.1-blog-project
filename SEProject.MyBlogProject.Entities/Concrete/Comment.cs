using SEProject.MyBlogProject.Entities.Interfaces;
using System;

namespace SEProject.MyBlogProject.Entities.Concrete
{
    public class Comment : ITable
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
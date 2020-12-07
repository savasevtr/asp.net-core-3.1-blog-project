﻿using SEProject.MyBlogProject.Entities.Interfaces;

namespace SEProject.MyBlogProject.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
﻿using Microsoft.EntityFrameworkCore;
using SEProject.MyBlogProject.Entities.Concrete;

namespace SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=BlogDb; Integrated Security=true;");
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
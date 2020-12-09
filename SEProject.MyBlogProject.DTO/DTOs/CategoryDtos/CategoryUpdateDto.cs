﻿using SEProject.MyBlogProject.DTO.Interfaces;

namespace SEProject.MyBlogProject.DTO.DTOs.CategoryDtos
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
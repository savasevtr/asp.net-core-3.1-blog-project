﻿using System;

namespace SEProject.MyBlogProject.DTO.DTOs.CommentDtos
{
    public class CommentAddDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }

        public int? ParentCommentId { get; set; }

        public int BlogId { get; set; }
    }
}
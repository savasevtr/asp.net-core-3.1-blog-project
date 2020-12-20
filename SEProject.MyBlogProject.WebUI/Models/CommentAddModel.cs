﻿using System;

namespace SEProject.MyBlogProject.WebUI.Models
{
    public class CommentAddModel
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
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEProject.MyBlogProject.Entities.Concrete;

namespace SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.AuthorName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.AuthorEmail).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(500).IsRequired();

            //builder.HasMany(I => I.SubComments).WithOne(I => I.ParentComment).HasForeignKey(I => I.ParentCommentId);
            builder.HasOne(I => I.ParentComment).WithMany(I => I.SubComments).HasForeignKey(I => I.ParentCommentId);
        }
    }
}
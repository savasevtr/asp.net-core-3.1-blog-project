﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.DTO.DTOs.BlogDtos;
using SEProject.MyBlogProject.Entities.Concrete;
using SEProject.MyBlogProject.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogAddModel blogAddModel)
        {
            if (blogAddModel.Image != null)
            {
                if (blogAddModel.Image.ContentType != "image/jpeg")
                {
                    return BadRequest("Dosya formatı geçerli değil");
                }

                var newName = Guid.NewGuid() + Path.GetExtension(blogAddModel.Image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img" + newName);
                var stream = new FileStream(path, FileMode.Create);
                await blogAddModel.Image.CopyToAsync(stream);
                blogAddModel.ImagePath = newName;
            }

            await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));

            return Created("", blogAddModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
            {
                return BadRequest("geçersiz id");
            }

            if (blogUpdateModel.Image != null)
            {
                if (blogUpdateModel.Image.ContentType != "image/jpeg")
                {
                    return BadRequest("Dosya formatı geçerli değil");
                }

                var newName = Guid.NewGuid() + Path.GetExtension(blogUpdateModel.Image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img" + newName);
                var stream = new FileStream(path, FileMode.Create);
                await blogUpdateModel.Image.CopyToAsync(stream);
                blogUpdateModel.ImagePath = newName;
            }

            await _blogService.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Blog { Id = id });

            return NoContent();
        }
    }
}
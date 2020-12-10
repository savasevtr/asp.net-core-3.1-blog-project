﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.DTO.DTOs.BlogDtos;
using SEProject.MyBlogProject.Entities.Concrete;
using SEProject.MyBlogProject.WebApi.Enums;
using SEProject.MyBlogProject.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
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
        public async Task<IActionResult> Create([FromForm]BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFile(blogAddModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                blogAddModel.ImagePath = uploadModel.NewName;
                await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm]BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
            {
                return BadRequest("geçersiz id");
            }

            var uploadModel = await UploadFile(blogUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                blogUpdateModel.ImagePath = uploadModel.NewName;
                await _blogService.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                await _blogService.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Blog { Id = id });

            return NoContent();
        }
    }
}
﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.Business.Utilities.FacadeTools;
using SEProject.MyBlogProject.DTO.DTOs.BlogDtos;
using SEProject.MyBlogProject.DTO.DTOs.CategoryBlogDtos;
using SEProject.MyBlogProject.DTO.DTOs.CategoryDtos;
using SEProject.MyBlogProject.DTO.DTOs.CommentDtos;
using SEProject.MyBlogProject.Entities.Concrete;
using SEProject.MyBlogProject.WebApi.CustomFilters;
using SEProject.MyBlogProject.WebApi.Enums;
using SEProject.MyBlogProject.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IFacade _facade;

        public BlogsController(IBlogService blogService, ICommentService commentService, IMapper mapper, IFacade facade)
        {
            _blogService = blogService;
            _commentService = commentService;
            _mapper = mapper;
            _facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //if (_facade.MemoryCache.TryGetValue("blogs", out List<BlogListDto> list))
            //{
            //    return Ok(list);
            //}

            var blogs = _mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync());

            //_facade.MemoryCache.Set("blogs", blogs, new MemoryCacheEntryOptions()
            //{
            //    AbsoluteExpiration = DateTime.Now.AddDays(1),
            //    Priority = CacheItemPriority.Normal
            //});

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm]BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg");

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
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> Update(int id, [FromForm]BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
            {
                return BadRequest("geçersiz id");
            }

            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);

                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;
                updatedBlog.ImagePath = uploadModel.NewName;

                await _blogService.UpdateAsync(updatedBlog);

                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;

                await _blogService.UpdateAsync(updatedBlog);

                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> Delete(int id)
        {
            // await _blogService.RemoveAsync(new Blog { Id = id });

            await _blogService.RemoveAsync(await _blogService.FindByIdAsync(id));

            return NoContent();
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> AddToCategory(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.AddToCategoryAsync(categoryBlogDto);

            return Created("", categoryBlogDto);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveFromCategory([FromQuery]CategoryBlogDto categoryBlogDto)
        {
            await _blogService.RemoveFromCategoryAsync(categoryBlogDto);

            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(await _blogService.GetAllByCategoryIdAsync(id));
        }

        [HttpGet("{id}/[action]")]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> GetCategories(int id)
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _blogService.GetCategoriesAsync(id)));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastFive()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetLastFiveAsync()));
        }

        [HttpGet("{id}/[action]")]
        public async Task<IActionResult> GetComments([FromRoute]int id, int? parentCommentId)
        {
            return Ok(_mapper.Map<List<CommentListDto>>(await _commentService.GetAllWithSubCommentsAsync(id, parentCommentId)));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Search([FromQuery]string s)
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.SearchAsync(s)));
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> AddComment(CommentAddDto commentAddDto)
        {
            commentAddDto.PostedTime = DateTime.Now;

            await _commentService.AddAsync(_mapper.Map<Comment>(commentAddDto));

            return Created("", commentAddDto);
        }
    }
}
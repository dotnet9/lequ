﻿using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentListByBlog(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke(int id)
        {
            var comments = _commentService.List(id).Result;
            var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return View(commentDtos);
        }
    }
}
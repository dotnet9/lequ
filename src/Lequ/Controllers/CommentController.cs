﻿using AutoMapper;
using Lequ.IService;
using Lequ.Model;
using Lequ.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentController(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Leave(Comment comment)
        {
            comment.CreateUserID = 1;
            comment.CreateDate = DateTime.Now;
            comment.Status = ModelStatus.Normal;
            await _service.InsertAsync(comment);
            return RedirectToAction("Details", "Blog", new { id = comment.BlogID });
        }
    }
}

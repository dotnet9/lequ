using AutoMapper;
using Lequ.IService;
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

        [HttpGet]
        public async Task<IActionResult> Leave(int blogID)
        {
            ViewBag.BlogID = blogID;
            return await Task.FromResult(PartialView());
        }

        [HttpPost]
        public async Task<IActionResult> Leave(Comment comment)
        {
            comment.CreateDate = DateTime.Now;
            comment.Status = ModelStatus.Normal;
            await _service.InsertAsync(comment);
            return PartialView();
        }
    }
}

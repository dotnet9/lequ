using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentList(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogID)
        {
            ViewBag.blogID = blogID;
            var comments = await _service.SelectAsync(x => x.BlogID == blogID);
            return View(comments);
        }
    }
}

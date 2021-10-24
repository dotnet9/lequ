using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		private readonly IMapper _mapper;

		public CommentController(ICommentService commentService, IMapper mapper)
		{
			_commentService = commentService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<PartialViewResult> Add()
		{
			return await Task.FromResult( PartialView());
		}

		public async Task<PartialViewResult> List(int postID)
		{
			var comments = await _commentService.List(postID);
			var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
			return PartialView(comments);
		}
	}
}

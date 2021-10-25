using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
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
			var comments = await _service.GetListByPost(postID);
			var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
			return PartialView(comments);
		}
	}
}

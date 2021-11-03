using AutoMapper;
using Lequ.IService;
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
		public async Task<IActionResult> Leave()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

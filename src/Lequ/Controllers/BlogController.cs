using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService _service;
		private readonly IMapper _mapper;

		public BlogController(IBlogService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			return await Task.FromResult(View());
		}

		[HttpGet]
		public async Task<IActionResult> ListByUser()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> ListByCategory()
		{
			return await Task.FromResult(View());
		}

		[HttpGet]
		public async Task<IActionResult> Featured()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> OtherFeatured()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> EmailSubscribe()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> Details()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> Cover()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> ReadAll()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

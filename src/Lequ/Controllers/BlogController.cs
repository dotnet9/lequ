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
		public async Task<PartialViewResult> List()
		{
			var values = await _service.GetAllAsync();
			return PartialView(values);
		}

		[HttpGet]
		public async Task<PartialViewResult> ListByUser()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> ListByCategory()
		{
			return await Task.FromResult(View());
		}

		[HttpGet]
		public async Task<PartialViewResult> Featured()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> OtherFeatured()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> EmailSubscribe()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> Details()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> Cover()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> ReadAll()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _service;

		public CategoryController(ICategoryService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _service.GetAllAsync();
			return View(values);
		}

		[HttpGet]
		public async Task<PartialViewResult> BlogDetailsCategoryList()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

using Lequ.Blog.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
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
			var values = await _service.GetAll();
			return View(values);
		}
	}
}

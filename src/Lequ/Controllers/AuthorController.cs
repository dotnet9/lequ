using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class AuthorController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> About()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> Popular()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

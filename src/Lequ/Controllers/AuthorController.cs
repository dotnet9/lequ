using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class AuthorController : Controller
	{
		[HttpGet]
		public async Task<PartialViewResult> About()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> Popular()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

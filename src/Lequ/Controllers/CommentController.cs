using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class CommentController : Controller
	{

		[HttpGet]
		public async Task<IActionResult> List()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<IActionResult> Leave()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

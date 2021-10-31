using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class CommentController : Controller
	{

		[HttpGet]
		public async Task<PartialViewResult> List()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> Leave()
		{
			return await Task.FromResult(PartialView());
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

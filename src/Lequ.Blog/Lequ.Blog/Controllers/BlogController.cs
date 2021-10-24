using Lequ.Blog.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _blogService.GetAll();
            return View(values);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class ErrorPageController : Controller
    {
        public async Task<IActionResult> Error1()
        {
            return await Task.FromResult(View());
        }
    }
}

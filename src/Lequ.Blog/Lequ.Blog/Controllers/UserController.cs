using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> UserProfile()
        {
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> UserEmail()
        {
            return await Task.FromResult(View());
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class AdminController : Controller
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

        [AllowAnonymous]
        public async Task<IActionResult> Test()
        {
            return await Task.FromResult(View());
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> NavbarPartial()
        {
            return await Task.FromResult(PartialView());
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> SidebarPartial()
        {
            return await Task.FromResult(PartialView());
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> FooterPartial()
        {
            return await Task.FromResult(PartialView());
        }
    }
}

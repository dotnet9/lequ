using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Lequ.Blog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserInfoService _service;
        private readonly IMapper _mapper;

        public LoginController(IUserInfoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(UserInfo userInfo)
        {
            var dbusers = await _service.ListAsync(x => x.Email == userInfo.Email && x.Password == userInfo.Password);
            var dbuser = dbusers.FirstOrDefault();
            if (dbuser != null && dbuser.Email != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dbuser.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}

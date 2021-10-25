using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.Models;
using Lequ.Blog.Service.ValidationRules;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IUserInfoService _service;
		private readonly IMapper _mapper;

		public RegisterController(IUserInfoService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserInfo user)
		{
			UserInfoValidator uv = new UserInfoValidator();
			var results = uv.Validate(user);
			if (results.IsValid)
			{
				user.Status = true;
				user.About = "Create user test";
				await _service.Add(user);
				return RedirectToAction("Index", "Blog");
			}
            else
            {
                foreach (var item in results.Errors)
                {
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
			return View();
		}
	}
}

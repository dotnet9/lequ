using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.Models;
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
			user.Status = true;
			user.About = "Create user test";
			await _service.Add(user);
			return RedirectToAction("Index", "Blog");
		}
	}
}

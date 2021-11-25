using System.Security.Claims;
using AutoMapper;
using Lequ.GlobalVar;
using Lequ.IService;
using Lequ.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers;

public class LoginController : Controller
{
	private readonly IMapper _mapper;
	private readonly IUserService _service;

	public LoginController(IUserService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> UserLogin()
	{
		return await Task.FromResult(View());
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> UserLogin(User user)
	{
		var dbUser = await _service.GetAsync(x => x.Account == user.Account && x.Password == user.Password);
		if (dbUser == null) return View();

		var claims = new List<Claim>
		{
			new(ClaimTypes.Name, dbUser.Account)
		};
		var userIdentity = new ClaimsIdentity(claims, "Account");
		var principal = new ClaimsPrincipal(userIdentity);
		HttpContext.Session.Set(GlobalVars.SessionUserAccountKey, dbUser.Account);
		HttpContext.Session.Set(GlobalVars.SessionUserIdKey, dbUser.ID);
		await HttpContext.SignInAsync(principal);
		return RedirectToAction("AdminBlogList", "Blog");
	}


	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync();
		return RedirectToAction("Index", "Home");
	}
}
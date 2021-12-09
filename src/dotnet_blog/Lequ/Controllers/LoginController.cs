using System.Security.Claims;
using AutoMapper;
using Lequ.GlobalVar;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
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
	public async Task<IActionResult> UserLogin(LoginDto loginDto)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		var dbUser = await _service.GetAsync(x => x.Account == loginDto.Account && x.Password == loginDto.Password);
		if (dbUser == null)
		{
			ViewBag.ErrorInfo = "User name or password invalid.";
			return View();
		}

		var claims = new List<Claim>
		{
			new(ClaimTypes.Name, dbUser.Account!)
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
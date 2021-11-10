﻿using AutoMapper;
using Lequ.IService;
using Lequ.Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lequ.Controllers
{
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
			if (dbUser == null)
			{
				return View();
			}
			var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, dbUser.Account)
				};
			var userIdentity = new ClaimsIdentity(claims, "a");
			ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
			await HttpContext.SignInAsync(principal);
			return RedirectToAction("Index", "User");
		}
	}
}
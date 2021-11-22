using AutoMapper;
using Lequ.GlobalVar;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.User;

public class UserProfileSettings : ViewComponent
{
	private readonly IMapper _mapper;
	private readonly IUserService _service;

	public UserProfileSettings(IUserService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var userID = HttpContext.Session.Get<int>(GlobalVars.SESSION_USER_ID_KEY);
		if (userID <= 0) return View();
		var dbUser = await _service.GetAsync(x => x.ID == userID);
		if (dbUser == null) return View();
		return View(dbUser);
	}
}
using AutoMapper;
using Lequ.Common;
using Lequ.Extensions;
using Lequ.IService;
using Lequ.Model.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.User
{
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
			var userID = HttpContext.Session.Get<int>(GlobalVar.SESSION_USER_ID_KEY);
			if (userID <= 0)
			{
				return View();
			}
			var dbUser = await _service.GetAsync(x => x.ID == userID);
			if (dbUser == null)
			{
				return View();
			}
			return View(dbUser);
        }
    }
}
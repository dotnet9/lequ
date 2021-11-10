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
			var account = HttpContext.Session.Get<string>(GlobalVar.SESSION_ACCOUNT_KEY);
			if (string.IsNullOrWhiteSpace(account))
			{
				return View();
			}
			var dbUser = await _service.GetAsync(x => x.Account == account);
			if (dbUser == null)
			{
				return View();
			}
			var vm = _mapper.Map<UserViewModel>(dbUser);
			return View(vm);
        }
    }
}
using Lequ.GlobalVar;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Home
{
	public class SetTheme : ViewComponent
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public SetTheme(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var vm = new SetThemeDto
			{
				Theme = _httpContextAccessor?.HttpContext?.Request?.Cookies[GlobalVars.CookiesThemeKey]?.ToString()
					.ToLower()
			};
			return await Task.FromResult(View(vm));
		}
	}
}
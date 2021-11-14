using AutoMapper;
using Lequ.GlobalVar;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    [Authorize]
	public class UserController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IUserService _service;
		private readonly IBlogService _blogService;

		public UserController(IUserService service, IMapper mapper, IBlogService blogService)
		{
			_service = service;
			_mapper = mapper;
			_blogService = blogService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return await Task.FromResult(View());
		}

		[HttpGet]
		public async Task<IActionResult> UserBlogList(int page = 1)
		{
			var userID = HttpContext.Session.Get<int>(GlobalVars.SESSION_USER_ID_KEY);
			if (userID <= 0)
			{
				return View();
			}
			var pageBlog = await _blogService.SelectAsync(pageSize: GlobalVars.PAGINATION_SMALL_PAGE_SIZE, pageIndex: page,
				whereLambda: x => x.CreateUserID == userID, orderByLambda: x => x.CreateDate, sortDirection: SortDirection.Descending);
			var vm = new PagingViewModelBase<Blog>();
			if (pageBlog != null && pageBlog.Item1.Count > 0)
			{
				vm.PageCount = (pageBlog.Item2 + GlobalVars.PAGINATION_SMALL_PAGE_SIZE - 1) / GlobalVars.PAGINATION_SMALL_PAGE_SIZE;
				vm.PageIndex = page < 1 ? 1 : page;
				vm.PageIndex = vm.PageIndex > vm.PageCount ? vm.PageCount : vm.PageIndex;
				vm.Datas = pageBlog.Item1;
			}

			return View(vm);
		}

		public async Task<IActionResult> AdminUserList(int page = 1)
		{
			var pageUser = await _service.SelectAsync(pageSize: GlobalVars.PAGINATION_SMALL_PAGE_SIZE, pageIndex: page,
				whereLambda: x => x.ID > 0, orderByLambda: x => x.CreateDate, sortDirection: SortDirection.Descending);
			var vm = new PagingViewModelBase<UserViewModel>();
			if (pageUser != null && pageUser.Item1.Count > 0)
			{
				var userVM = _mapper.Map<List<UserViewModel>>(pageUser.Item1);
				vm.PageCount = (pageUser.Item2 + GlobalVars.PAGINATION_SMALL_PAGE_SIZE - 1) / GlobalVars.PAGINATION_SMALL_PAGE_SIZE;
				vm.PageIndex = page < 1 ? 1 : page;
				vm.PageIndex = vm.PageIndex > vm.PageCount ? vm.PageCount : vm.PageIndex;
				vm.Datas = userVM;
			}

			return View(vm);
		}


		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var vm = new AddUserViewModel();
			vm.Statuses = Enum.GetValues<ModelStatus>();
			return await Task.FromResult(View(vm));
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddUserViewModel user)
		{
			var dbUser = _mapper.Map<User>(user);
			dbUser.CreateDate = DateTime.Now;
			dbUser.UpdateDate = DateTime.Now;
			await _service.InsertAsync(dbUser);
			return RedirectToAction(nameof(AdminUserList));
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(x => x.ID == id);
			return RedirectToAction(nameof(AdminUserList));
		}


		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var dbUser = await _service.GetAsync(x => x.ID == id);
			if (dbUser == null) return RedirectToAction(nameof(AdminUserList));
			var vm = _mapper.Map<UpdateUserViewModel>(dbUser);
			vm.Statuses = Enum.GetValues<ModelStatus>();
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateUserViewModel user)
		{
			var dbUser = await _service.GetAsync(x => x.ID == user.ID);
			if (dbUser == null) return RedirectToAction(nameof(AdminUserList));

			_mapper.Map(user, dbUser, typeof(UpdateUserViewModel), typeof(User));
			dbUser.UpdateDate = DateTime.Now;
			await _service.UpdateAsync(dbUser);
			return RedirectToAction(nameof(AdminUserList));
		}
	}
}
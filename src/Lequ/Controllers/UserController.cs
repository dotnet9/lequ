using AutoMapper;
using Lequ.Common;
using Lequ.IService;
using Lequ.Model;
using Lequ.Model.Models;
using Lequ.Model.ViewModels;
using Lequ.Model.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminUserList(int page = 1)
        {
            var pageUser = await _service.SelectAsync(pageSize: GlobalVar.SMALL_PAGE_SIZE, pageIndex: page, whereLambda: x => x.ID > 0, orderByLambda: x => x.CreateDate, sortDirection: SortDirection.Descending);
            var vm = new PagingViewModelBase<UserViewModel>();
            if (pageUser != null && pageUser.Item1.Count > 0)
            {
                var userVM = _mapper.Map<List<UserViewModel>>(pageUser.Item1);
                vm.PageCount = (pageUser.Item2 + GlobalVar.SMALL_PAGE_SIZE - 1) / GlobalVar.SMALL_PAGE_SIZE;
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
            if (dbUser == null)
            {
                return RedirectToAction(nameof(AdminUserList));
            }
            var vm = _mapper.Map<UpdateUserViewModel>(dbUser);
            vm.Statuses = Enum.GetValues<ModelStatus>();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel user)
        {
            var dbUser = await _service.GetAsync(x => x.ID == user.ID);
            if (dbUser == null)
            {
                return RedirectToAction(nameof(AdminUserList));
            }

            _mapper.Map(user, dbUser, typeof(UpdateUserViewModel), typeof(User));
            dbUser.UpdateDate = DateTime.Now;
            await _service.UpdateAsync(dbUser);
            return RedirectToAction(nameof(AdminUserList));
        }
    }
}

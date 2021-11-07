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
            var pageUser = await _service.SelectAsync(pageSize: GlobalVar.SMALL_PAGE_SIZE, pageIndex: page, whereLambda: x=>x.ID > 0, orderByLambda: x=>x.CreateDate, sortDirection: SortDirection.Descending);
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
    }
}

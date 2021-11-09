using Lequ.Common;
using Lequ.IService;
using Lequ.Model;
using Lequ.Model.Models;
using Lequ.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _service.SelectAsync();
            return View(values);
        }

        public async Task<IActionResult> AdminCategoryList(int page = 1)
        {
            var pageCategory = await _service.SelectAsync(pageSize: GlobalVar.SMALL_PAGE_SIZE, pageIndex: page,
                whereLambda: x => x.ID > 0, orderByLambda: x => x.CreateDate, sortDirection: SortDirection.Descending);
            var vm = new PagingViewModelBase<Category>();
            if (pageCategory != null && pageCategory.Item1.Count > 0)
            {
                vm.PageCount = (pageCategory.Item2 + GlobalVar.SMALL_PAGE_SIZE - 1) / GlobalVar.SMALL_PAGE_SIZE;
                vm.PageIndex = page < 1 ? 1 : page;
                vm.PageIndex = vm.PageIndex > vm.PageCount ? vm.PageCount : vm.PageIndex;
                vm.Datas = pageCategory.Item1;
            }

            return View(vm);
        }
    }
}
using AutoMapper;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.About
{
    public class Footer : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IAboutService _service;
        private readonly ILinkService _linkService;

        public Footer(IAboutService service, ILinkService linkService, IMapper mapper)
        {
            _service = service;
            _linkService = linkService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new FooterViewModel();
            vm.FriendLinks = await _linkService.SelectAsync(whereLambda: x => x.Status == (int)ModelStatus.Normal, orderByLambda: x => x.Index, sortDirection: SortDirection.Ascending);
            return View(vm);
        }
    }
}
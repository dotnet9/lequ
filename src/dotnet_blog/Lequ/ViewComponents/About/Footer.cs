using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.About
{
    public class Footer : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IAboutService _service;

        public Footer(IAboutService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _service.SelectAsync();
            return View(values);
        }
    }
}
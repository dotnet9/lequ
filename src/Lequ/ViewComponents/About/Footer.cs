using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.About
{
    public class Footer: ViewComponent
    {
        private readonly IAboutService _service;
        private readonly IMapper _mapper;

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

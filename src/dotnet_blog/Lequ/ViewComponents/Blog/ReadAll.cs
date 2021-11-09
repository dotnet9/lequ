using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Blog
{
    public class ReadAll : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _service;

        public ReadAll(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blog = await _service.GetDetailsAsync(id);
            return View(blog);
        }
    }
}
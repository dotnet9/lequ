using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Category
{
    public class BlogDetailsCategoryList : ViewComponent
    {
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public BlogDetailsCategoryList(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int blogID)
        {
            var value = await _service.GetDetailsAsync(blogID);
            return View(value.BlogCategories);
        }
    }
}

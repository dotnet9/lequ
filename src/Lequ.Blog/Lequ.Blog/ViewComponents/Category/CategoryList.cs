using AutoMapper;
using Lequ.Blog.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryList(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = _service.GetAllAsync().Result;
            return View(values);
        }
    }
}

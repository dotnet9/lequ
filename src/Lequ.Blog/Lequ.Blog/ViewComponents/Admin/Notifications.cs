using AutoMapper;
using Lequ.Blog.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.ViewComponents.Admin
{
    public class Notifications : ViewComponent
    {
        private readonly IUserInfoService _service;
        private readonly IMapper _mapper;

        public Notifications(IUserInfoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke(int id)
        {
            //var posts = _service.ToListByUserIDAsync(1).Result;
            //var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View();
        }
    }
}

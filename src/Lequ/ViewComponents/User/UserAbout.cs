using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.User
{
    public class UserAbout : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserAbout(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogID)
        {
            var user = await _service.GetByBlogID(blogID);
            return View(user);
        }
    }
}
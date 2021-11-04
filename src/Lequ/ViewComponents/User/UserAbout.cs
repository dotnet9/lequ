using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.User
{
    public class UserAbout : ViewComponent
    {
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public UserAbout(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int blogID)
        {
            var blog = await _service.GetAsync(x => x.ID == blogID, x => x.User);
            return View(blog?.User);
        }
    }
}
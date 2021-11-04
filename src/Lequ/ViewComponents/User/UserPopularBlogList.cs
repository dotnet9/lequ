using AutoMapper;
using Lequ.IService;
using Lequ.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.User
{
    public class UserPopularBlogList : ViewComponent
    {
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public UserPopularBlogList(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _service.SelectAsync(6, 1, x => x.UserID == id, x => x.CreateDate, SortDirection.Descending);
            return View(value.Item1);
        }
    }
}

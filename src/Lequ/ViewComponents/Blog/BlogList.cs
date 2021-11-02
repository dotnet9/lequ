using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Blog
{
	public class BlogList : ViewComponent
	{
		private readonly IBlogService _service;
		private readonly IMapper _mapper;

		public BlogList(IBlogService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IViewComponentResult> InvokeAsync(int page = 1)
		{
			var values = await _service.ListWithCategoryAsync(page, 6);
			if (ViewBag.blogs == null)
			{
				ViewBag.blogs = new List<Lequ.Model.Models.Blog>();
			}
			ViewBag.blogs.AddRange(values.Item1);

			return View(values.Item1.Count > 0);
		}
	}
}

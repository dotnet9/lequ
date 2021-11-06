using AutoMapper;
using Lequ.Model.Models;
using Lequ.Model.ViewModels.Blogs;

namespace Lequ.Extensions.AutoMapper
{
    public class CustomProfile : Profile
	{
		public CustomProfile()
		{
			CreateMap<Blog, AddBlogViewModel>().ReverseMap();
			CreateMap<Blog, UpdateBlogViewModel>().ReverseMap();
			//CreateMap<Category, CategoryDto>();
			//CreateMap<Comment, CommentDto>();
			//CreateMap<Model.Models.Blog, BlogDto>().ReverseMap();
		}
	}
}

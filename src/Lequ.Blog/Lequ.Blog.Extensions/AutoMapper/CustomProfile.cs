using AutoMapper;
using Lequ.Blog.Model.Models;
using Lequ.Blog.Model.ViewModels;

namespace Lequ.Blog.Extensions.AutoMapper
{
	public class CustomProfile:Profile
	{
		public CustomProfile()
		{
			CreateMap<Category, CategoryDto>();
			CreateMap<Comment, CommentDto>();
			CreateMap<Model.Models.Blog, BlogDto>().ReverseMap();
		}
	}
}

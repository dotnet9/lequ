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
			CreateMap<Model.Models.Blog, BlogDto>();
		}
	}
}

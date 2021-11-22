using AutoMapper;
using Lequ.Models;
using Lequ.ViewModels;

namespace Lequ.AutoMapper;

public class CustomProfile : Profile
{
	public CustomProfile()
	{
		CreateMap<Blog, BlogForCreationDto>().ReverseMap();
		CreateMap<Blog, BlogFotUpdateDto>().ReverseMap();
		CreateMap<Comment, CommentDto>();
		CreateMap<User, UserDto>();
		CreateMap<UserForCreationDto, User>();
		CreateMap<User, UserForUpdateDto>().ReverseMap();
		CreateMap<LinkForCreationDto, Link>();
		CreateMap<LinkForUpdateDto, Link>().ReverseMap();
	}
}
using AutoMapper;
using Lequ.Models;
using Lequ.ViewModels;

namespace Lequ.AutoMapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Blog, AddBlogViewModel>().ReverseMap();
            CreateMap<Blog, UpdateBlogViewModel>().ReverseMap();
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserViewModel>();
            CreateMap<AddUserViewModel, User>();
            CreateMap<User, UpdateUserViewModel>().ReverseMap();
            CreateMap<CreateLinkViewModel, Link>();
            CreateMap<UpdateLinkViewModel, Link>().ReverseMap();
        }
    }
}
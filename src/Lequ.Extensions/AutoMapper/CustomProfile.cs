using AutoMapper;
using Lequ.Model.Models;
using Lequ.Model.ViewModels.Blogs;
using Lequ.Model.ViewModels.Comments;
using Lequ.Model.ViewModels.Users;

namespace Lequ.Extensions.AutoMapper
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
            //CreateMap<Category, CategoryDto>();
            //CreateMap<Model.Models.Blog, BlogDto>().ReverseMap();
        }
    }
}
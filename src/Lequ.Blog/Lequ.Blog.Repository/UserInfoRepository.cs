﻿using Lequ.Blog.Model.Models;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{ 
    public class UserInfoRepository : RepositoryBase<UserInfo, int>, IUserInfoRepository
    {
        public UserInfoRepository(Context context) : base(context)
        {
        }
    }
}

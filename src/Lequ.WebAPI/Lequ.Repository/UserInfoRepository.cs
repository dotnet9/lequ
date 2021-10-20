using System;
using Lequ.IRepository;
using Lequ.Model;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public class UserInfoRepository : RepositoryBase<UserInfo, int>, IUserInfoRepository
    {
        public UserInfoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}


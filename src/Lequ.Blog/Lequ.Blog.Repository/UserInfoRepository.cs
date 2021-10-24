using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{ 
    public class UserInfoRepository : RepositoryBase<UserInfo, int>, IUserInfoRepository
    {
        public UserInfoRepository(DbContext dBContext) : base(dBContext)
        {
        }
    }
}

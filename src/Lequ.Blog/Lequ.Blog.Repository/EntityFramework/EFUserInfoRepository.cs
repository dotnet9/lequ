using Lequ.Blog.Entity;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository.EntityFramework
{ 
    public class EFUserInfoRepository : RepositoryBase<UserInfo, int>, IUserInfoRepository
    {
        public EFUserInfoRepository(Context context) : base(context)
        {
        }
    }
}

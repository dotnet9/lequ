using Lequ.Blog.Model;
using Lequ.Blog.IRepository;
using Lequ.Blog.IService;

namespace Lequ.Blog.Service
{
    public class UserInfoService : ServiceBase<UserInfo, int>, IUserInfoService
    {
        public UserInfoService(IUserInfoRepository repository)
        {
            base.repositoryBase = repository;
        }
    }
}

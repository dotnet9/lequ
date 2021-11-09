using Lequ.Model.Models;

namespace Lequ.IService
{
    public interface IUserService : IBaseService<User>
    {
        Task<User?> GetByBlogID(int id);
    }
}
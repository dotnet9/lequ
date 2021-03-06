using Lequ.Models;

namespace Lequ.IRepository;

public interface IUserRepository : IBaseRepository<User>
{
	Task<User?> GetByBlogID(int id);
}
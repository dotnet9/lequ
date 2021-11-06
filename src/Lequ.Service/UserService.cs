using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model;

namespace Lequ.Service
{
	public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _currentRepository;
        public UserService(IUserRepository repository):base(repository)
        {
            this._currentRepository = repository;
        }
    }
}

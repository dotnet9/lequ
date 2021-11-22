using Lequ.IRepository;
using Lequ.IService;
using Lequ.Models;

namespace Lequ.Service;

public class UserService : BaseService<User>, IUserService
{
	private readonly IUserRepository _currentRepository;

	public UserService(IUserRepository repository) : base(repository)
	{
		_currentRepository = repository;
	}

	public async Task<User?> GetByBlogID(int id)
	{
		return await _currentRepository.GetByBlogID(id);
	}
}
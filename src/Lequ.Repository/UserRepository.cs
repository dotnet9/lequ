using Lequ.IRepository;
using Lequ.Model;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
	public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LequDbContext context) : base(context)
        {
        }
    }
}

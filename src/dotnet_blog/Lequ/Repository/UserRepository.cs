using Lequ.IRepository;
using Lequ.Models;

namespace Lequ.Repository
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(LequDbContext context) : base(context)
		{
		}

		public async Task<User?> GetByBlogID(int id)
		{
			var user = from tempUser in dbContext.Users
					   join tempBlog in dbContext.Blogs
						   on tempUser.ID equals tempBlog.CreateUserID
					   where tempBlog.ID == id
					   select tempUser;

			return user.FirstOrDefault();
		}
	}
}
using Lequ.Blog.IRepository;
using Lequ.Blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lequ.Blog.Extensions.ServiceExtensions
{
	public static class DbSetup
	{
		public static void AddDbSetup(this IServiceCollection services)
		{
			if(services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			services.AddDbContext<Context>(option =>
			{
				option.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Lequ.Blog;integrated security=true;");
			});
		}
	}
}

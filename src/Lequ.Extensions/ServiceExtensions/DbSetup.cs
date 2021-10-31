using Lequ.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lequ.Extensions.ServiceExtensions
{
	public static class DbSetup
	{
		public static void AddDbSetup(this IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			services.AddDbContext<Context>(option =>
			{
				option.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Lequ;integrated security=true;");
			});
		}
	}
}

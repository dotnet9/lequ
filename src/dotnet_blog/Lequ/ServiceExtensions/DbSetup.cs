using Lequ.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.ServiceExtensions;

public static class DbSetup
{
	public static void AddDbSetup(this IServiceCollection services, string connectionStr)
	{
		if (services == null) throw new ArgumentNullException(nameof(services));

		//services.AddDbContext<LequDbContext>(option => { option.UseSqlServer(connectionStr); });
		services.AddDbContext<LequDbContext>(option => { option.UseMySql(connectionStr, MySqlServerVersion.LatestSupportedServerVersion); });
	}
}
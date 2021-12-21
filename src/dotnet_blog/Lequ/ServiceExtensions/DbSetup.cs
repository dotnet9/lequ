using Lequ.GlobalVar;
using Lequ.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.ServiceExtensions;

public static class DbSetup
{
	public static void AddDbSetup(this IServiceCollection services, string connectionStr, string environmentName)
	{
		if (services == null) throw new ArgumentNullException(nameof(services));

		//services.AddDbContext<LequDbContext>(option => { option.UseSqlServer(connectionStr); });
		services.AddDbContext<LequDbContext>(option =>
		{
			if (environmentName == GlobalVars.EnvironmentNameDevelopment)
				option.UseSqlServer(connectionStr);
			else
				option.UseSqlite(connectionStr);
			//option.UseMySql(connectionStr, MySqlServerVersion.LatestSupportedServerVersion);
		});
	}
}
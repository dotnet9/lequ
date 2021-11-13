using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Lequ.Extensions.ServiceExtensions
{
    public static class MixedLocalizationSetup
    {
        public static void AddMixedLocalizationSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddMixedLocalization(opts =>
                {
                    opts.ResourcesPath = "Resources";
                },
                options => options.UseSettings(true, false, true, true)
            );

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var cultures = configuration.GetSection("Internationalization").GetSection("Cultures")
                        .Get<List<string>>()
                        .Select(x => new CultureInfo(x)).ToList();
                    var supportedCultures = cultures;

                    var defaultRequestCulture = cultures.FirstOrDefault() ?? new CultureInfo("en-US");
                    options.DefaultRequestCulture = new RequestCulture(culture: defaultRequestCulture, uiCulture: defaultRequestCulture);
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                }
            );
        }
    }
}

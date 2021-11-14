using FluentValidation;
using Lequ.FluentValidation;
using Lequ.ViewModels;

namespace Lequ.ServiceExtensions
{
    public static class FluentValidationSetup
    {
        public static void AddFluentValidationSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IValidator<LinkForCreationDto>, LinkForCreationDtoValidator>();
            services.AddTransient<IValidator<LinkForUpdateDto>, LinkForUpdateDtoValidator>();
        }
    }
}

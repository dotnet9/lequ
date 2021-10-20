using System;
using Lequ.IRepository;
using Lequ.IService;
using Lequ.Repository;
using Lequ.Services;

namespace Lequ.WebAPI.Utility
{
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        {
            services.AddScoped<IPostInfoRepository, PostInfoRepository>();
            services.AddScoped<IPostInfoService, PostInfoService>();
            services.AddScoped<ICategoryInfoRepository, CategoryInfoRepository>();
            services.AddScoped<ICategoryInfoService, CategoryInfoService>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            return services;
        }
        public static IServiceCollection AddCustomJWT(this IServiceCollection services)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //      .AddJwtBearer(options =>
            //      {
            //          options.TokenValidationParameters = new TokenValidationParameters
            //          {
            //              ValidateIssuerSigningKey = true,
            //              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF")),
            //              ValidateIssuer = true,
            //              ValidIssuer = "http://localhost:6060",
            //              ValidateAudience = true,
            //              ValidAudience = "http://localhost:5000",
            //              ValidateLifetime = true,
            //              ClockSkew = TimeSpan.FromMinutes(60)
            //          };
            //      });
            return services;
        }
    }
}


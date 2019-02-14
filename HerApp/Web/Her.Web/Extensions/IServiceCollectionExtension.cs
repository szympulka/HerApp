using System;
using Her.Context;
using Her.Domain.Entities;
using Her.Services.VersionServcie;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Her.Web.Extensions
{
    public static class IServiceCollectionExtension
    {

        public static IServiceCollection IdentityServcie(this IServiceCollection services)
        {
			services.AddIdentity<ApplicationUser, IdentityRole>(config =>
			{
				config.SignIn.RequireConfirmedEmail = true;
			})
				.AddEntityFrameworkStores<HerContext>()
				.AddDefaultTokenProviders();
			services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/login");
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
				options.Password.RequiredUniqueChars = 6;

				// Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
				options.Lockout.MaxFailedAccessAttempts = 10;
				options.Lockout.AllowedForNewUsers = true;

				// User settings
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedEmail = true;
			});


			return services;

        }
    }
}

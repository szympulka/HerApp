using Her.Services.AzureServices;
using Her.Services.DashboardService;
using Her.Services.DictionaryService;
using Her.Services.EmailService;
using Her.Services.FunctionalityService;
using Her.Services.StatisticsService;
using Her.Services.TaskService;
using Her.Services.UserService;
using Her.Services.VersionServcie;
using Her.Services.WrocService;
using Microsoft.Extensions.DependencyInjection;

namespace Her.Services.Extensions
{
    public static class IServicesCollectionExtension
    {

        public static IServiceCollection Services(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService.EmailService>();
            services.AddTransient<IUserService, UserService.UserService>();
            services.AddTransient<ITaskCategoryService, TaskCategoryService>();
            services.AddTransient<ITaskService, TaskService.TaskService>();
            services.AddTransient<IFunctionalityService, FunctionalityService.FunctionalityService>();
            services.AddTransient<IDashboardService, DashboardService.DashboardService>();
	        services.AddTransient< IQueueServcie, QueueServcie>();
			services.AddTransient<ICosmoDbService, CosmoDbService>();
			services.AddTransient<IWrocService, WrocService.WrocService>();
			services.AddTransient<IDictionaryServices, DictionaryServices>();
			services.AddTransient<IVersionService, VersionService>();

			services.AddTransient<UserStatisticsService>();
	        services.AddTransient<UserResolverService>();

			return services;
        }
    }
}

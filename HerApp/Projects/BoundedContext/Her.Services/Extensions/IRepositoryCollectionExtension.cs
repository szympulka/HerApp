using Her.Repository.User;
using Her.Repository.Version;
using Microsoft.Extensions.DependencyInjection;
using Her.Repository.Dictionary;
using Her.Repository.Notification;
using Her.Repository.Task;
using Her.Repository.Wro;

namespace Her.Services.Extensions
{
	public static class IRepositoryCollectionExtension
	{
		public static IServiceCollection Repository(this IServiceCollection services)
		{
			services.AddTransient<IVersionRepository, VersionRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ITaskRepository, TaskRepository>();
			services.AddTransient<ITaskCategoryRepository, TaskCategoryRepository>();
			services.AddTransient<INotificationRepository, NotificationRepository>();
			services.AddTransient<IInterestRepository, InterestRepository>();
			services.AddTransient<IWrocItemsRepository, WrocItemsRepository>();
			services.AddTransient<IUserDailyWroEventsRepository, UserDailyWroEventsRepository>();
			services.AddTransient<IMPKInfoRepository, MPKInfoRepository>();
			services.AddTransient<IWeatherRepository, WeatherRepository>();

			return services;
		}
	}
}

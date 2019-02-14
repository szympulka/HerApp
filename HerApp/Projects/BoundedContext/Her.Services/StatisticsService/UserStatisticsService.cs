using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Her.Commons.Enums.Domain;
using Her.Repository.Notification;
using Her.Repository.User;
using Her.Repository.Version;
using Her.Services.Extensions;
using Her.ViewModel.StaticViewModels;

namespace Her.Services.StatisticsService
{
    public class UserStatisticsService
    {
        private IUserRepository _userRepository;
        private IVersionRepository _versionRepository;
        private INotificationRepository _notificationRepository;
				private readonly string _currentUser;

        public UserStatisticsService(IUserRepository userRepository, IVersionRepository versionRepository, INotificationRepository notificationRepository,UserResolverService userService)
        {
            _userRepository = userRepository;
            _versionRepository = versionRepository;
            _notificationRepository = notificationRepository;
	        _currentUser = userService.GetUserName();
        }
        public string GetName()
        {
            var user = _userRepository.All().First(x => x.UserName == _currentUser);
            return user.Name + " " + user.Surname;
        }

        public string GetBotName()
        {
            return _userRepository.All().First(x => x.UserName == _currentUser).BotName;
        }

        public string GetUserNameName()
        {
            return _userRepository.All().First(x => x.UserName == _currentUser).UserName;
        }

        public string MemberSince()
        {
			
            return _userRepository.All().First(x => x.UserName == _currentUser).CreatedDate.ToString("Y");
        }

        public string Version()
        {
			var version = _versionRepository.All().FirstOrDefault();
			if(version == null)
			{
				version = new Domain.Entities.VersionModel();
				version.VersionNumber = new Version("1.0.0").ToString();
				version.VersionType = VersionTypeEnum.Dev;
				_versionRepository.Add(version);
				_versionRepository.SaveChanges();
			}

			return version.VersionType + " " +version.VersionNumber;
        }

        public IEnumerable<NotificationViewModel> Notification()
        {
            var user = _userRepository.All().First(x => x.UserName == _currentUser);
            var notification = new List<NotificationViewModel>();
            var model = _notificationRepository.All().Where(x => !x.IsReaded &&( x.UserID == user.Id || x.UserID == null )).ToList();
            foreach (var m in model)
            {
                notification.Add(new NotificationViewModel()
                {
                    Id = m.Id,
                    ImportantValue = m.ImportantValue,
                    DateAdded = m.CreatedDate,
                    Title = m.Text
                });
            }
            return notification.Take(10).OrderByDescending(x=> x.ImportantValue);
        }
    }
}

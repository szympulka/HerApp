using System;
using System.Linq;
using Her.Commons.Enums.Domain;
using Her.Repository.Version;

namespace Her.Services.VersionServcie
{
	public class VersionService : IVersionService
	{
		private IVersionRepository _versionRepository;

		public VersionService(IVersionRepository versionRepository)
		{
			_versionRepository = versionRepository;
		}

		public void UpdateBuildVersion(VersionTypeEnum typeEnum)
		{
			var versionApp = _versionRepository.All().FirstOrDefault();
			if (versionApp == null)
			{
				versionApp = new Domain.Entities.VersionModel();
				versionApp.VersionNumber = new Version("1.0.0").ToString();
				versionApp.VersionType = VersionTypeEnum.Dev;
				_versionRepository.Add(versionApp);
				_versionRepository.SaveChanges();
			}
			else
			{
				var version = Version.Parse(versionApp.VersionNumber);
				var build = version.Build;
				build++;
				versionApp.CreateDateTime = DateTime.Now;
				versionApp.VersionType = typeEnum;
				versionApp.LastVersionNumber = versionApp.VersionNumber;
				versionApp.VersionNumber = new Version(version.Major, version.Minor, build).ToString();
				_versionRepository.Update(versionApp);
				_versionRepository.SaveChanges();
			}
		}

		public void UpdateMinorVersion(VersionTypeEnum typeEnum)
		{
			var versionApp = _versionRepository.All().First();
			var version = Version.Parse(versionApp.VersionNumber);
			var minor = version.Minor;
			minor++;

			versionApp.CreateDateTime = DateTime.Now;
			versionApp.VersionType = typeEnum;
			versionApp.LastVersionNumber = versionApp.VersionNumber;
			versionApp.VersionNumber = new Version(version.Major, minor, 0).ToString();
			_versionRepository.Update(versionApp);
			_versionRepository.SaveChanges();
		}

		public void UpdateMajordVersion(VersionTypeEnum typeEnum)
		{
			var versionApp = _versionRepository.All().First();
			var version = Version.Parse(versionApp.VersionNumber);
			var major = version.Major;
			major++;

			versionApp.CreateDateTime = DateTime.Now;
			versionApp.VersionType = typeEnum;
			versionApp.LastVersionNumber = versionApp.VersionNumber;
			versionApp.VersionNumber = new Version(major, 0, 0).ToString();
			_versionRepository.Update(versionApp);
			_versionRepository.SaveChanges();
		}
	}
}

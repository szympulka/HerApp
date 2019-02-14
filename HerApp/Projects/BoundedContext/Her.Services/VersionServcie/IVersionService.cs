using Her.Commons.Enums.Domain;

namespace Her.Services.VersionServcie
{
    public interface IVersionService
    {
        void UpdateBuildVersion(VersionTypeEnum typeEnum);
        void UpdateMinorVersion(VersionTypeEnum typeEnum);
        void UpdateMajordVersion(VersionTypeEnum typeEnum);
    }
}

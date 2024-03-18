using Volo.Abp.Reflection;

namespace TDM.DeviceService.Permissions;

public class DeviceServicePermissions
{
    public const string GroupName = "DeviceService";
    public static class Device
    {
        public const string Default = GroupName + ".Project";
        public const string Create = Default + ".Create";
    }
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(DeviceServicePermissions));
    }
}

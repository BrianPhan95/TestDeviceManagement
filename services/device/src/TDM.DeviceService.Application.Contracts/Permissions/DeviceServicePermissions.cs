using Volo.Abp.Reflection;

namespace TDM.DeviceService.Permissions;

public class DeviceServicePermissions
{
    public const string GroupName = "DeviceService";
    public static class Device
    {
        public const string Default = GroupName + ".Device";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string CheckOut = Default + ".CheckOut";
        public const string Return = Default + ".Return";

    }
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(DeviceServicePermissions));
    }
}

using TDM.DeviceService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TDM.DeviceService.Permissions;

public class DeviceServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(DeviceServicePermissions.GroupName, L("Permission:DeviceService"));

        var deviceGroup = context.AddGroup(DeviceServicePermissions.GroupName, L("Permission:DeviceService"));
        var devicePermission = deviceGroup.AddPermission(DeviceServicePermissions.Device.Default, L("Permission:DeviceService:Default"));
        devicePermission.AddChild(DeviceServicePermissions.Device.Create);
        devicePermission.AddChild(DeviceServicePermissions.Device.Update);
        devicePermission.AddChild(DeviceServicePermissions.Device.Delete);
        devicePermission.AddChild(DeviceServicePermissions.Device.CheckOut);
        devicePermission.AddChild(DeviceServicePermissions.Device.Return);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DeviceServiceResource>(name);
    }
}

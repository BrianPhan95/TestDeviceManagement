using System;
using System.Collections.Generic;
using System.Text;
using TDM.DeviceService.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace TDM.DeviceService.Features
{
    public class DeviceServiceFeaturesDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup(DeviceServiceFeatures.GroupName);
            myGroup.AddFeature(
                DeviceServiceFeatures.Device.Default,
                defaultValue: "false",
                displayName: L("Device"),
                valueType: new ToggleStringValueType());
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DeviceServiceResource>(name);
        }
    }

}

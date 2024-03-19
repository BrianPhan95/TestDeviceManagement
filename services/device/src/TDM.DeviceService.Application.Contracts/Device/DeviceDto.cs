using System;
using System.Collections.Generic;
using System.Text;
using TDM.DeviceService.Devices;
using Volo.Abp.Application.Dtos;

namespace TDM.DeviceService
{
    public class DeviceDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
    }
}

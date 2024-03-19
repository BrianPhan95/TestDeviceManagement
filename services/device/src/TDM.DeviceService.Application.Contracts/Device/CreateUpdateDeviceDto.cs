using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.DeviceService.Devices;

namespace TDM.DeviceService
{
    public class CreateUpdateDeviceDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public DeviceType DeviceType { get; set; } = DeviceType.Unknown;
        public DeviceStatus DeviceStatus { get; set; } = DeviceStatus.Available;
    }
}

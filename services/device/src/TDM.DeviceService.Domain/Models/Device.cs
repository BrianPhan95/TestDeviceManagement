using System;
using System.Collections.Generic;
using System.Text;
using TDM.DeviceService.Devices;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace TDM.DeviceService.Models
{

    public class Device : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public DeviceType DeviceType { get; set; }
        public DeviceStatus DeviceStatus { get; set; }


        public virtual ICollection<DeviceBooking> DeviceBookings { get; set; } = new List<DeviceBooking>();

        public Device(string name, DeviceType deviceType, DeviceStatus deviceStatus)
        {
            Name = name;
            DeviceType = deviceType;
            DeviceStatus = deviceStatus;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace TDM.DeviceService.Domain
{

    public class Device : AggregateRoot<Guid>, IMultiTenant
    {
        public string Name { get; set; }

        public Guid? TenantId { get; set; }

        public Device(string name)
        {
            Name = name;
        }
    }

}

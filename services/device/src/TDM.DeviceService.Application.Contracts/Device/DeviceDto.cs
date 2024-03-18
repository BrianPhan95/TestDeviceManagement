using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace TDM.DeviceService
{
    public class DeviceDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}

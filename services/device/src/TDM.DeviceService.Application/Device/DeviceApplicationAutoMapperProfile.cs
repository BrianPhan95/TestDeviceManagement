using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;

namespace TDM.DeviceService.Device
{
    public class DeviceApplicationAutoMapperProfile : Profile
    {
        public DeviceApplicationAutoMapperProfile()
        {
            CreateMap<CreateUpdateDeviceDto, Domain.Device>().Ignore(x => x.TenantId).Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id); ;
            CreateMap<Domain.Device, DeviceDto>();
        }
    }
}

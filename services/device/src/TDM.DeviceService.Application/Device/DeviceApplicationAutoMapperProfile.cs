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
            CreateMap<CreateUpdateDeviceDto, Models.Device>()
                .Ignore(x => x.ExtraProperties)
                .Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id)
                .Ignore(x => x.DeviceBookings);

            CreateMap<Models.Device, DeviceDto>().Ignore(x => x.BookingBy);
        }
    }
}

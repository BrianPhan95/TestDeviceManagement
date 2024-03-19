using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.DeviceService.Models;
using Volo.Abp.AutoMapper;

namespace TDM.DeviceService.DeviceBookings
{
    public class DeviceBookingApplicationAutoMapperProfile : Profile
    {
        public DeviceBookingApplicationAutoMapperProfile()
        {
            CreateMap<CreateUpdateDeviceBookingDto, DeviceBooking>()
                .Ignore(x => x.ExtraProperties)
                .Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id)
                .Ignore(x => x.Device);

            CreateMap<DeviceBooking, DeviceBookingDto>();
        }
    }
}

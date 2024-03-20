using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.DeviceService.DeviceBookings;
using TDM.DeviceService.Models;
using Volo.Abp.AutoMapper;

namespace TDM.DeviceService.UserBookingInfomations
{
    public class UserBookingApplicationAutoMapperProfile : Profile
    {
        public UserBookingApplicationAutoMapperProfile()
        {
            CreateMap<CreateUpdateUserBookingDto, Models.UserBooking>()
               .Ignore(x => x.ExtraProperties)
               .Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id)
               .Ignore(x => x.TenantId)
               .Ignore(x => x.DeviceBookings);

            CreateMap<Models.UserBooking, UserBookingDto>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.DeviceService.DeviceBookings;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TDM.DeviceService.UserBookingInfomations
{
    public interface IUserBookingAppService : ICrudAppService<
      UserBookingDto,
      Guid,
      PagedAndSortedResultRequestDto,
      CreateUpdateUserBookingDto>
    {
        Task CreateUpdateUserBooking(Guid userId, CreateUpdateUserBookingDto dto);
    }
}

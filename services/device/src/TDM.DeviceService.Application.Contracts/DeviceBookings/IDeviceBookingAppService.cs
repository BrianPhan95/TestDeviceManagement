﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TDM.DeviceService.DeviceBookings
{
    public interface IDeviceBookingAppService : ICrudAppService< 
       DeviceBookingDto,
       Guid, 
       PagedAndSortedResultRequestDto,
       CreateUpdateDeviceBookingDto> 
    {
        Task CheckoutDevice(Guid deviceId);
        Task BookingReturn(Guid deviceId);
    }
}

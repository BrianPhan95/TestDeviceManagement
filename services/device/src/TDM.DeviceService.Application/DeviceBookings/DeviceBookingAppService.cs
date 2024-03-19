using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.DeviceService.Features;
using TDM.DeviceService.Models;
using TDM.DeviceService.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;

namespace TDM.DeviceService.DeviceBookings
{
    [RequiresFeature(DeviceServiceFeatures.Device.Default)]
    [Authorize(DeviceServicePermissions.Device.Default)]
    public class DeviceBookingAppService : CrudAppService<
                            Models.DeviceBooking, DeviceBookingDto, Guid,
                               PagedAndSortedResultRequestDto,
                               CreateUpdateDeviceBookingDto>,
                           IDeviceBookingAppService
    {
        private IRepository<DeviceBooking, Guid> _deviceBookingRepository;
        private IRepository<Models.Device, Guid> _deviceRepository;
        public DeviceBookingAppService(IRepository<Models.DeviceBooking, Guid> repository, IRepository<Models.Device, Guid> deviceRepository)
            : base(repository)
        {
            _deviceBookingRepository = repository;
            _deviceRepository = deviceRepository;
        }

        public async Task BookingReturn(Guid deviceId)
        {
            var lastBooking = await _deviceBookingRepository.FirstOrDefaultAsync(d => d.DeviceId == deviceId && d.IsActive);
            if (lastBooking == null)
            {
                throw new Exception("Booking not found");
            }

            var device = await _deviceRepository.FirstOrDefaultAsync(d => d.Id == deviceId);
            if (device == null)
            {
                throw new Exception("Device not found");
            }
            
            device.DeviceStatus = Devices.DeviceStatus.Available;
            await _deviceRepository.UpdateAsync(device);

            lastBooking.IsActive = false;
            lastBooking.TimeReturn = DateTime.Now;
            await _deviceBookingRepository.UpdateAsync(lastBooking);
        }
    }
}

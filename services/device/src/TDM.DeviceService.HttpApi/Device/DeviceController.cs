using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.DeviceService;
using TDM.DeviceService.DeviceBookings;
using TDM.DeviceService.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;
using Volo.Abp.ObjectMapping;

namespace TDM.DeviceServices
{

    [Area(DeviceServiceRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = DeviceServiceRemoteServiceConsts.RemoteServiceName)]
    [Route("api/device")]
    public class DeviceController : DeviceServiceController
    {
        private readonly IDeviceAppService _deviceService;
        private readonly IDeviceBookingAppService _deviceBookingService;

        public DeviceController(IDeviceAppService sampleAppService, IDeviceBookingAppService deviceBookingService)
        {
            _deviceService = sampleAppService;
            _deviceBookingService = deviceBookingService;
        }

        [HttpGet]
        [Authorize(DeviceServicePermissions.Device.Default)]
        public async Task<PagedResultDto<DeviceDto>> GetListAsync(PagedAndSortedResultRequestDto dto)
        {
            return await _deviceService.GetListAsync(dto);
        }


        [HttpPost]
        [Authorize(DeviceServicePermissions.Device.Create)]
        public async Task<DeviceDto> Create(CreateUpdateDeviceDto deviceDto)
        {
            return await _deviceService.CreateAsync(deviceDto);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(DeviceServicePermissions.Device.Update)]
        public async Task<DeviceDto> GetAsync(Guid id)
        {
            return await _deviceService.GetAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(DeviceServicePermissions.Device.Update)]
        public async Task<DeviceDto> UpdateAsync(Guid id, CreateUpdateDeviceDto deviceDto)
        {
            return await _deviceService.UpdateAsync(id, deviceDto);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(DeviceServicePermissions.Device.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _deviceService.DeleteAsync(id);
        }

        /// check out
        ///  <summary>
        /// check out
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Authorize(DeviceServicePermissions.Device.CheckOut)]
        [Route("checkout/{deviceId}")]
        public async Task CheckOutAsync(Guid deviceId)
        {
            await _deviceBookingService.CheckoutDevice(deviceId);
        }

        [HttpPost]
        [Authorize(DeviceServicePermissions.Device.Return)]
        [Route("return/{deviceId}")]
        public async Task ReturnAsync(Guid deviceId)
        {
            await _deviceBookingService.BookingReturn(deviceId);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDM.DeviceService;
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

        public DeviceController(IDeviceAppService sampleAppService)
        {
            _deviceService = sampleAppService;
        }

        [HttpGet]
        [Authorize(DeviceServicePermissions.Device.Default)]
        public async Task<PagedResultDto<DeviceDto>> GetAllAsync(PagedAndSortedResultRequestDto dto)
        {
            return await _deviceService.GetListAsync(dto);
        }


        [HttpPost]
        [Authorize(DeviceServicePermissions.Device.Create)]
        public async Task<DeviceDto> Create(CreateUpdateDeviceDto deviceDto)
        {
            return await _deviceService.CreateAsync(deviceDto);
        }
    }


}

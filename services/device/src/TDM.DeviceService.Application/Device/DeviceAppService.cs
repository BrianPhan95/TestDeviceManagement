using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDM.DeviceService.Features;
using TDM.DeviceService.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;
using Volo.Abp.ObjectMapping;

namespace TDM.DeviceService.Domain.Application
{
    //[RequiresFeature(DeviceServiceFeatures.Device.Default)]
    //[Authorize(DeviceServicePermissions.Device.Default)]
    //public class DeviceAppService : DeviceServiceAppService, IDeviceAppService
    //{
    //    private readonly IRepository<Device, Guid> repository;

    //    public DeviceAppService(IRepository<Device, Guid> repository)
    //    {
    //        this.repository = repository;
    //    }

    //    [Authorize(DeviceServicePermissions.Device.Default)]
    //    public async Task<PagedResultDto<DeviceDto>> GetAllAsync()
    //    {
    //        var devices = await repository.GetListAsync();
    //        return ObjectMapper.Map<List<Device>, PagedResultDto<DeviceDto>>(devices);
    //    }

    //    [Authorize(DeviceServicePermissions.Device.Create)]
    //    public async Task<DeviceDto> Create(CreateUpdateDeviceDto deviceDto)
    //    {
    //        var Device = await repository.InsertAsync(new Device(deviceDto.Name));
    //        return new DeviceDto
    //        {
    //            Name = Device.Name
    //        };
    //    }
    //}

    [RequiresFeature(DeviceServiceFeatures.Device.Default)]
    [Authorize(DeviceServicePermissions.Device.Default)]
    public class DeviceAppService :
     CrudAppService<
         Models.Device,
         DeviceDto,
         Guid, 
         PagedAndSortedResultRequestDto, 
         CreateUpdateDeviceDto>, 
     IDeviceAppService 
    {
        public DeviceAppService(IRepository<Models.Device, Guid> repository)
            : base(repository)
        {

        }
    }
}

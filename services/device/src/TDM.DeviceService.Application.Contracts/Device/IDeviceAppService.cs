﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TDM.DeviceService
{
    public interface IDeviceAppService : ICrudAppService<DeviceDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDeviceDto>
    {
    }
}

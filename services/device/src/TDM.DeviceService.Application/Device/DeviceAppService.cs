using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TDM.DeviceService.Features;
using TDM.DeviceService.Permissions;
using Volo.Abp.Application;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;
using Volo.Abp.ObjectMapping;

namespace TDM.DeviceService.Domain.Application
{
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
        private IRepository<Models.DeviceBooking, Guid> _deviceBookingRepository;
        private IRepository<Models.Device, Guid> _deviceRepository;

        public DeviceAppService(IRepository<Models.Device, Guid> repository, IRepository<Models.DeviceBooking, Guid> bookingRepository)
            : base(repository)
        {
            _deviceRepository = repository;
            _deviceBookingRepository = bookingRepository;
        }

        public override async Task<PagedResultDto<DeviceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = new PagedResultDto<DeviceDto>();

            var query = await _deviceRepository.GetQueryableAsync();
            if (string.IsNullOrEmpty(input.Sorting))
            {
                query = query.OrderBy(d => d.ConcurrencyStamp);
            }
            else if (input.Sorting.StartsWith("bookingBy"))
            {
                string[] words = input.Sorting.Split(' ');
                if (words[1] == "desc")
                    query = query.OrderByDescending(d => d.DeviceBookings.Any())
                                .OrderByDescending(d => d.DeviceBookings.OrderBy(d => d.TimeCheckOut).First().User.UserName);
                else
                    query = query.OrderBy(d => d.DeviceBookings.Any())
                                .OrderBy(d => d.DeviceBookings.OrderBy(d => d.TimeCheckOut).First().User.UserName);
            }
            else
            {
                query = query.OrderBy(input.Sorting);
            }

            result.TotalCount = query.Count();

            query = query.Skip(input.SkipCount).Take(input.MaxResultCount);


            result.Items = query.Select(d => new DeviceDto()
            {
                Id = d.Id,
                BookingBy = d.DeviceBookings.Any() ? d.DeviceBookings.OrderBy(d => d.TimeCheckOut).First().User.UserName : "",
                DeviceStatus = d.DeviceStatus,
                DeviceType = d.DeviceType,
                Name = d.Name
            }).ToList();

            return result;

        }

    }
}

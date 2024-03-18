using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TDM.DeviceService
{
    //public interface IDeviceAppService : IApplicationService
    //{
    //    Task<PagedResultDto<DeviceDto>> GetAllAsync();

    //    Task<DeviceDto> Create(CreateUpdateDeviceDto deviceDto);
    //}
    public interface IDeviceAppService : ICrudAppService< //Defines CRUD methods
        DeviceDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateDeviceDto> //Used to create/update a book
    {

    }
}

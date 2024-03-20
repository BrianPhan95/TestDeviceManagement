using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TDM.DeviceService.DeviceBookings;
using TDM.DeviceService.Features;
using TDM.DeviceService.Models;
using TDM.DeviceService.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;

namespace TDM.DeviceService.UserBookingInfomations
{
    public class UserBookingAppService :
    CrudAppService<UserBooking, UserBookingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserBookingDto>, IUserBookingAppService
    {
        private IRepository<UserBooking, Guid> _userBookingRepository;
        public UserBookingAppService(IRepository<UserBooking, Guid> repository) : base(repository)
        {
            _userBookingRepository = repository;
        }


        public async Task CreateUpdateUserBooking(Guid userId, CreateUpdateUserBookingDto dto)
        {
            var userIsExist = await _userBookingRepository.FirstOrDefaultAsync(d => d.UserId == userId);

            if (userIsExist == null)
            {
                //await base.CreateAsync(dto);

                UserBooking userBooking = new UserBooking()
                {
                    UserId = userId,
                    UserName = dto.UserName,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    TenantId = dto.TenantId
                };
                await _userBookingRepository.InsertAsync(userBooking);
            }
            else
            {
                //await base.UpdateAsync(userId, dto);
                userIsExist.UserName = dto.UserName;
                userIsExist.Name = dto.Name;
                userIsExist.Surname = dto.Surname;
                userIsExist.TenantId = dto.TenantId;
                await _userBookingRepository.UpdateAsync(userIsExist);
            }
        }
    }
}

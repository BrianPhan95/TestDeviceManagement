using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using Volo.Abp.Users;
using Volo.Abp.Identity;
using TDM.DeviceService.UserBookingInfomations;
using TDM.DeviceService.DeviceBookings;

namespace TDM.DeviceService.EventHandler
{

    public class UserCreatedOrUpdatedEventHandler : IDistributedEventHandler<IdentityUserUserNameChangedEto>, ITransientDependency
    {
        private readonly ILogger<UserCreatedOrUpdatedEventHandler> _logger;
        private IUserBookingAppService _userBookingAppService;

        public UserCreatedOrUpdatedEventHandler(
            ILogger<UserCreatedOrUpdatedEventHandler> logger,
            IUserBookingAppService userBookingAppService)
        {
            _logger = logger;
            _userBookingAppService = userBookingAppService;
        }

        public async Task HandleEventAsync(IdentityUserUserNameChangedEto eventData)
        {
            try
            {
                _logger.LogInformation($"UserID: ${eventData.Id}");
                CreateUpdateUserBookingDto userBookingDto = new CreateUpdateUserBookingDto()
                {
                    Name = eventData.UserName,
                    Surname = eventData.UserName,
                    TenantId = eventData.TenantId,
                    UserName = eventData.UserName,
                };
                _logger.LogInformation($"UserID: ${userBookingDto.Name}");
                _logger.LogInformation($"Surname: ${userBookingDto.Surname}");
                _logger.LogInformation($"TenantId: ${userBookingDto.TenantId}");
                _logger.LogInformation($"UserName: ${userBookingDto.UserName}");


                await _userBookingAppService.CreateUpdateUserBooking(eventData.Id, userBookingDto);
            }
            catch (Exception ex)
            {
                await HandleErroruserCreatedAsync(eventData, ex);
            }
        }

        private Task HandleErroruserCreatedAsync(IdentityUserUserNameChangedEto eventData, Exception ex)
        {
            _logger.LogInformation($"Error: ${ex.Message}");
            throw new NotImplementedException();
        }
    }
}

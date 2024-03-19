using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TDM.DeviceService.DeviceBookings
{
    public class DeviceBookingDto : EntityDto<Guid>
    {
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeCheckOut { get; set; } = DateTime.Now;
        public DateTime? TimeReturn { get; set; }
    }
}

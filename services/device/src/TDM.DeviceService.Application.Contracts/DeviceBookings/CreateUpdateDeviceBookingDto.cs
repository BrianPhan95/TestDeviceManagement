using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM.DeviceService.DeviceBookings
{
    public class CreateUpdateDeviceBookingDto
    {
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeCheckOut { get; set; } = DateTime.Now;
        public DateTime? TimeReturn { get; set; }
    }
}

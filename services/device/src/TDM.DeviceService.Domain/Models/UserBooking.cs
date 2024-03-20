using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TDM.DeviceService.Models
{
    public class UserBooking : AggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public Guid? TenantId { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public virtual ICollection<DeviceBooking> DeviceBookings { get; set; } = new List<DeviceBooking>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TDM.DeviceService.Devices;
using Volo.Abp.Domain.Entities;

namespace TDM.DeviceService.Models
{
    public class DeviceBooking : AggregateRoot<Guid>
    {
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set;}
        public bool IsActive { get; set; }
        public DateTime TimeCheckOut { get; set; } = DateTime.Now;
        public DateTime? TimeReturn { get; set; }

        [ForeignKey("DeviceId")]
        public Device Device { get; set; }

        [ForeignKey("UserId")]
        public UserBooking User { get; set; }

        public DeviceBooking()
        {
            
        }
    }
}

using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TDM.DeviceService.EntityFrameworkCore;

[ConnectionStringName(DeviceServiceDbProperties.ConnectionStringName)]
public interface IDeviceServiceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}

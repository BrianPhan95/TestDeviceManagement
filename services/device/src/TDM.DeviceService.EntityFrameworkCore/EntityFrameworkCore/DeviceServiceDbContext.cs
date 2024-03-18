using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TDM.DeviceService.EntityFrameworkCore;

[ConnectionStringName(DeviceServiceDbProperties.ConnectionStringName)]
public class DeviceServiceDbContext : AbpDbContext<DeviceServiceDbContext>, IDeviceServiceDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DeviceServiceDbContext(DbContextOptions<DeviceServiceDbContext> options)
        : base(options)
    {

    }
    public DbSet<Domain.Device> Devices { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureDeviceService();
    }
}

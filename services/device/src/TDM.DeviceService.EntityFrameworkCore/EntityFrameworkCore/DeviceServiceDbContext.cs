using Microsoft.EntityFrameworkCore;
using TDM.DeviceService.Models;
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
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceBooking> DeviceBookings {  get; set; }
    public DbSet<UserBooking> UserBookings {  get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureDeviceService();
    }
}

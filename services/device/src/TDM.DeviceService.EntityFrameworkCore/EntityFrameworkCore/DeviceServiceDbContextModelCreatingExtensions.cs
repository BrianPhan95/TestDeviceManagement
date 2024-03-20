using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using TDM.DeviceService.Models;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TDM.DeviceService.EntityFrameworkCore;

public static class DeviceServiceDbContextModelCreatingExtensions
{
    public static void ConfigureDeviceService(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(DeviceServiceDbProperties.DbTablePrefix + "Questions", DeviceServiceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */


        builder.Entity<Device>(b =>
        {
            //Configure table & schema name
            b.ToTable(DeviceServiceDbProperties.DbTablePrefix + "Devices", DeviceServiceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Relations
            b.HasMany(device => device.DeviceBookings)
            .WithOne(booking => booking.Device)
            .HasForeignKey(qt => qt.DeviceId);
        });


        builder.Entity<DeviceBooking>(b =>
        {
            //Configure table & schema name
            b.ToTable(DeviceServiceDbProperties.DbTablePrefix + "DeviceBookings", DeviceServiceDbProperties.DbSchema);

            b.ConfigureByConvention();

            b.HasOne<Device>(booking => booking.Device).WithMany(device => device.DeviceBookings).HasForeignKey(e => e.DeviceId);
            b.HasOne<UserBooking>(booking => booking.User).WithMany(user => user.DeviceBookings).HasForeignKey(e => e.UserId);

        });

        builder.Entity<UserBooking>(b =>
        {
            //Configure table & schema name
            b.ToTable(DeviceServiceDbProperties.DbTablePrefix + "UserBookings", DeviceServiceDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Relations
            b.HasMany(user => user.DeviceBookings)
            .WithOne(booking => booking.User)
            .HasForeignKey(qt => qt.UserId);
        });
    }
}

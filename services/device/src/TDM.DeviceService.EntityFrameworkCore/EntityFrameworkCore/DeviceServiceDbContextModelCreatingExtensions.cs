﻿using Microsoft.EntityFrameworkCore;
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


        builder.Entity<Domain.Device>(b =>
        {
            //Configure table & schema name
            b.ToTable(DeviceServiceDbProperties.DbTablePrefix + "Devices", DeviceServiceDbProperties.DbSchema);

            b.ConfigureByConvention();
        });

    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.DeviceService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeviceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "DeviceServiceDevices");

            migrationBuilder.AddColumn<int>(
                name: "DeviceStatus",
                table: "DeviceServiceDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeviceType",
                table: "DeviceServiceDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceStatus",
                table: "DeviceServiceDevices");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "DeviceServiceDevices");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "DeviceServiceDevices",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}

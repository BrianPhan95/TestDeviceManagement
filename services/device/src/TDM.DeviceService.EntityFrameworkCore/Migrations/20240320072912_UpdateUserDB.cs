using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.DeviceService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "DeviceServiceUserBookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DeviceServiceUserBookings");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.DeviceService.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceServiceDeviceBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TimeCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeReturn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceServiceDeviceBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceServiceDeviceBookings_DeviceServiceDevices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "DeviceServiceDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceServiceDeviceBookings_DeviceId",
                table: "DeviceServiceDeviceBookings",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceServiceDeviceBookings");
        }
    }
}

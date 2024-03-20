using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.DeviceService.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInfomation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceServiceUserBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceServiceUserBookings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceServiceDeviceBookings_UserId",
                table: "DeviceServiceDeviceBookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceServiceDeviceBookings_DeviceServiceUserBookings_UserId",
                table: "DeviceServiceDeviceBookings",
                column: "UserId",
                principalTable: "DeviceServiceUserBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceServiceDeviceBookings_DeviceServiceUserBookings_UserId",
                table: "DeviceServiceDeviceBookings");

            migrationBuilder.DropTable(
                name: "DeviceServiceUserBookings");

            migrationBuilder.DropIndex(
                name: "IX_DeviceServiceDeviceBookings_UserId",
                table: "DeviceServiceDeviceBookings");
        }
    }
}

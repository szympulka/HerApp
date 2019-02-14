using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _090720181859 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyWroIventsCount",
                schema: "user",
                table: "UserDailyNotificationModel",
                newName: "DailyWroEventCount");

            migrationBuilder.RenameColumn(
                name: "DailyWroIvents",
                schema: "user",
                table: "UserDailyNotificationModel",
                newName: "DailyWroEvent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyWroEventCount",
                schema: "user",
                table: "UserDailyNotificationModel",
                newName: "DailyWroIventsCount");

            migrationBuilder.RenameColumn(
                name: "DailyWroEvent",
                schema: "user",
                table: "UserDailyNotificationModel",
                newName: "DailyWroIvents");
        }
    }
}

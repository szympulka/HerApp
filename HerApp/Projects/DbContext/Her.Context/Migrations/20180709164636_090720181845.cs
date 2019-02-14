using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _090720181845 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyWroIventsCout",
                schema: "user",
                table: "UserDailyNotificationModel",
                newName: "DailyWroIventsCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyWroIventsCount",
                schema: "user",
                table: "UserDailyNotificationModel",
                newName: "DailyWroIventsCout");
        }
    }
}

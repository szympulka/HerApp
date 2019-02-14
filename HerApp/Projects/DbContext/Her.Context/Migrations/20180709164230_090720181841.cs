using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _090720181841 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DailyWroIvents",
                schema: "user",
                table: "UserDailyNotificationModel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DailyWroIventsCout",
                schema: "user",
                table: "UserDailyNotificationModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyWroIvents",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.DropColumn(
                name: "DailyWroIventsCout",
                schema: "user",
                table: "UserDailyNotificationModel");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _190720181516 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyWroEventCount",
                schema: "user",
                table: "UserCustomSettings");

            migrationBuilder.AddColumn<bool>(
                name: "DailyMpkInfo",
                schema: "user",
                table: "UserCustomSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DailyWeather",
                schema: "user",
                table: "UserCustomSettings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyMpkInfo",
                schema: "user",
                table: "UserCustomSettings");

            migrationBuilder.DropColumn(
                name: "DailyWeather",
                schema: "user",
                table: "UserCustomSettings");

            migrationBuilder.AddColumn<int>(
                name: "DailyWroEventCount",
                schema: "user",
                table: "UserCustomSettings",
                nullable: false,
                defaultValue: 0);
        }
    }
}

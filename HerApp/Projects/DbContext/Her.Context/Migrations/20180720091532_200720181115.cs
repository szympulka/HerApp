using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _200720181115 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxTemperature",
                schema: "Dictionary",
                table: "Weather",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinTemperature",
                schema: "Dictionary",
                table: "Weather",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                schema: "Dictionary",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                schema: "Dictionary",
                table: "Weather");
        }
    }
}

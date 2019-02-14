using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _200720181118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MinTemperature",
                schema: "Dictionary",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MaxTemperature",
                schema: "Dictionary",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinTemperature",
                schema: "Dictionary",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxTemperature",
                schema: "Dictionary",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

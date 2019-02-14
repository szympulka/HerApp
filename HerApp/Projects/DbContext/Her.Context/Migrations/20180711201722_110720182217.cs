using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _110720182217 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                schema: "wro",
                table: "WrocOfferAdresss");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "wro",
                table: "WrocMainImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "wro",
                table: "WrocOfferAdresss",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "wro",
                table: "WrocMainImage",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

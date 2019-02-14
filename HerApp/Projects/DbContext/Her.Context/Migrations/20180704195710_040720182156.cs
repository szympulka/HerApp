using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _040720182156 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IntrestID",
                schema: "Dictionary",
                table: "WroOffersCategory",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_WroOffersCategory_IntrestID",
                schema: "Dictionary",
                table: "WroOffersCategory",
                column: "IntrestID");

            migrationBuilder.AddForeignKey(
                name: "FK_WroOffersCategory_Interest_IntrestID",
                schema: "Dictionary",
                table: "WroOffersCategory",
                column: "IntrestID",
                principalSchema: "Dictionary",
                principalTable: "Interest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WroOffersCategory_Interest_IntrestID",
                schema: "Dictionary",
                table: "WroOffersCategory");

            migrationBuilder.DropIndex(
                name: "IX_WroOffersCategory_IntrestID",
                schema: "Dictionary",
                table: "WroOffersCategory");

            migrationBuilder.DropColumn(
                name: "IntrestID",
                schema: "Dictionary",
                table: "WroOffersCategory");
        }
    }
}

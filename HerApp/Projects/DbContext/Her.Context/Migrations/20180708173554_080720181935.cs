using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _080720181935 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WrocOfferCategories",
                schema: "wro",
                table: "WrocOfferCategories",
                newName: "WrocOfferCategoriesId");

            migrationBuilder.RenameColumn(
                name: "WricItemsId",
                schema: "wro",
                table: "WrocItems",
                newName: "WrocItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WrocOfferCategoriesId",
                schema: "wro",
                table: "WrocOfferCategories",
                newName: "WrocOfferCategories");

            migrationBuilder.RenameColumn(
                name: "WrocItemsId",
                schema: "wro",
                table: "WrocItems",
                newName: "WricItemsId");
        }
    }
}

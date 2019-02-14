using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _080720181817 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WroOffersCategory",
                schema: "Dictionary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WroOffersCategory",
                schema: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(nullable: true),
                    IntrestID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WroOffersCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WroOffersCategory_Interest_IntrestID",
                        column: x => x.IntrestID,
                        principalSchema: "Dictionary",
                        principalTable: "Interest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WroOffersCategory_IntrestID",
                schema: "Dictionary",
                table: "WroOffersCategory",
                column: "IntrestID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _080720181828 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wro");

            migrationBuilder.CreateTable(
                name: "WrocItems",
                schema: "wro",
                columns: table => new
                {
                    WricItemsId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<long>(nullable: false),
                    UrbancardPremium = table.Column<bool>(nullable: false),
                    PlaceName = table.Column<string>(nullable: true),
                    Premiere = table.Column<bool>(nullable: false),
                    Ticketing = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrocItems", x => x.WricItemsId);
                });

            migrationBuilder.CreateTable(
                name: "WrocOffer",
                schema: "wro",
                columns: table => new
                {
                    WrocOfferId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    ExternalLink = table.Column<string>(nullable: true),
                    OfferType = table.Column<string>(nullable: true),
                    PageLink = table.Column<string>(nullable: true),
                    WrocItemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrocOffer", x => x.WrocOfferId);
                    table.ForeignKey(
                        name: "FK_WrocOffer_WrocItems_WrocItemId",
                        column: x => x.WrocItemId,
                        principalSchema: "wro",
                        principalTable: "WrocItems",
                        principalColumn: "WricItemsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WrocOfferAdresss",
                schema: "wro",
                columns: table => new
                {
                    WrocOfferAdressId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<long>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    WrocItemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrocOfferAdresss", x => x.WrocOfferAdressId);
                    table.ForeignKey(
                        name: "FK_WrocOfferAdresss_WrocItems_WrocItemId",
                        column: x => x.WrocItemId,
                        principalSchema: "wro",
                        principalTable: "WrocItems",
                        principalColumn: "WricItemsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WrocMainImage",
                schema: "wro",
                columns: table => new
                {
                    WrocMainImageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<long>(nullable: false),
                    Standard = table.Column<string>(nullable: true),
                    Large = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    Tile = table.Column<string>(nullable: true),
                    Banner = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WrocOfferId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrocMainImage", x => x.WrocMainImageId);
                    table.ForeignKey(
                        name: "FK_WrocMainImage_WrocOffer_WrocOfferId",
                        column: x => x.WrocOfferId,
                        principalSchema: "wro",
                        principalTable: "WrocOffer",
                        principalColumn: "WrocOfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WrocOfferCategories",
                schema: "wro",
                columns: table => new
                {
                    WrocOfferCategories = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<long>(nullable: false),
                    WrocOfferId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrocOfferCategories", x => x.WrocOfferCategories);
                    table.ForeignKey(
                        name: "FK_WrocOfferCategories_WrocOffer_WrocOfferId",
                        column: x => x.WrocOfferId,
                        principalSchema: "wro",
                        principalTable: "WrocOffer",
                        principalColumn: "WrocOfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WrocOfferType",
                schema: "wro",
                columns: table => new
                {
                    WrocOfferTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    WrocOfferId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrocOfferType", x => x.WrocOfferTypeId);
                    table.ForeignKey(
                        name: "FK_WrocOfferType_WrocOffer_WrocOfferId",
                        column: x => x.WrocOfferId,
                        principalSchema: "wro",
                        principalTable: "WrocOffer",
                        principalColumn: "WrocOfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WrocMainImage_WrocOfferId",
                schema: "wro",
                table: "WrocMainImage",
                column: "WrocOfferId",
                unique: true,
                filter: "[WrocOfferId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WrocOffer_WrocItemId",
                schema: "wro",
                table: "WrocOffer",
                column: "WrocItemId",
                unique: true,
                filter: "[WrocItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WrocOfferAdresss_WrocItemId",
                schema: "wro",
                table: "WrocOfferAdresss",
                column: "WrocItemId",
                unique: true,
                filter: "[WrocItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WrocOfferCategories_WrocOfferId",
                schema: "wro",
                table: "WrocOfferCategories",
                column: "WrocOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_WrocOfferType_WrocOfferId",
                schema: "wro",
                table: "WrocOfferType",
                column: "WrocOfferId",
                unique: true,
                filter: "[WrocOfferId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WrocMainImage",
                schema: "wro");

            migrationBuilder.DropTable(
                name: "WrocOfferAdresss",
                schema: "wro");

            migrationBuilder.DropTable(
                name: "WrocOfferCategories",
                schema: "wro");

            migrationBuilder.DropTable(
                name: "WrocOfferType",
                schema: "wro");

            migrationBuilder.DropTable(
                name: "WrocOffer",
                schema: "wro");

            migrationBuilder.DropTable(
                name: "WrocItems",
                schema: "wro");
        }
    }
}

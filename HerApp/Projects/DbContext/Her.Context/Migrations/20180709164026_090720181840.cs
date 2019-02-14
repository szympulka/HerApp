using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _090720181840 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDailyWroEvents",
                schema: "User",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    WrocItemsID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDailyWroEvents", x => new { x.WrocItemsID, x.UserID });
                    table.UniqueConstraint("AK_UserDailyWroEvents_UserID_WrocItemsID", x => new { x.UserID, x.WrocItemsID });
                    table.ForeignKey(
                        name: "FK_UserDailyWroEvents_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDailyWroEvents_WrocItems_WrocItemsID",
                        column: x => x.WrocItemsID,
                        principalSchema: "wro",
                        principalTable: "WrocItems",
                        principalColumn: "WrocItemsId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDailyWroEvents",
                schema: "User");
        }
    }
}

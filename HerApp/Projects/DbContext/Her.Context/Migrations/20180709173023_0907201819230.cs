using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _0907201819230 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyWroEvent",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.DropColumn(
                name: "DailyWroEventCount",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.CreateTable(
                name: "UserCustomSettings",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyWroEvent = table.Column<bool>(nullable: false),
                    DailyWroEventCount = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCustomSettings_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "user",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomSettings_UserID",
                schema: "user",
                table: "UserCustomSettings",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCustomSettings",
                schema: "user");

            migrationBuilder.AddColumn<bool>(
                name: "DailyWroEvent",
                schema: "user",
                table: "UserDailyNotificationModel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DailyWroEventCount",
                schema: "user",
                table: "UserDailyNotificationModel",
                nullable: false,
                defaultValue: 0);
        }
    }
}

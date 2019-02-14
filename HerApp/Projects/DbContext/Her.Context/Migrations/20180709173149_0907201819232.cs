using Microsoft.EntityFrameworkCore.Migrations;

namespace Her.Context.Migrations
{
    public partial class _0907201819232 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDailyNotificationModel_AspNetUsers_UserID",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDailyNotificationModel",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.DropIndex(
                name: "IX_UserDailyNotificationModel_UserID",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "user",
                table: "UserDailyNotificationModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDailyNotificationModel",
                schema: "user",
                table: "UserDailyNotificationModel",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDailyNotificationModel_AspNetUsers_UserID",
                schema: "user",
                table: "UserDailyNotificationModel",
                column: "UserID",
                principalSchema: "user",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDailyNotificationModel_AspNetUsers_UserID",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDailyNotificationModel",
                schema: "user",
                table: "UserDailyNotificationModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "user",
                table: "UserDailyNotificationModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "user",
                table: "UserDailyNotificationModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDailyNotificationModel",
                schema: "user",
                table: "UserDailyNotificationModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDailyNotificationModel_UserID",
                schema: "user",
                table: "UserDailyNotificationModel",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDailyNotificationModel_AspNetUsers_UserID",
                schema: "user",
                table: "UserDailyNotificationModel",
                column: "UserID",
                principalSchema: "user",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

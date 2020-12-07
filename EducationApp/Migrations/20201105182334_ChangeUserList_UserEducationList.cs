using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationApp.Migrations
{
    public partial class ChangeUserList_UserEducationList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEducationLists_Users_UserId",
                table: "UserEducationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEducationLists",
                table: "UserEducationLists");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserEducationLists",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserEducationLists",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEducationLists",
                table: "UserEducationLists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducationLists_UserId",
                table: "UserEducationLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEducationLists_Users_UserId",
                table: "UserEducationLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEducationLists_Users_UserId",
                table: "UserEducationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEducationLists",
                table: "UserEducationLists");

            migrationBuilder.DropIndex(
                name: "IX_UserEducationLists_UserId",
                table: "UserEducationLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserEducationLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserEducationLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEducationLists",
                table: "UserEducationLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEducationLists_Users_UserId",
                table: "UserEducationLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

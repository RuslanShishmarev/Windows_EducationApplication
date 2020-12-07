using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationApp.Migrations
{
    public partial class AddNewColumnId_UserEducationList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEducationLists_Users_Id",
                table: "UserEducationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEducationLists",
                table: "UserEducationLists");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserEducationLists",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEducationLists_Users_UserId",
                table: "UserEducationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEducationLists",
                table: "UserEducationLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserEducationLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEducationLists",
                table: "UserEducationLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEducationLists_Users_Id",
                table: "UserEducationLists",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationApp.Migrations
{
    public partial class AddNewColumn_UserEducationList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEducationLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EducationObjectId = table.Column<int>(nullable: true),
                    Result = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducationLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEducationLists_EducationObjects_EducationObjectId",
                        column: x => x.EducationObjectId,
                        principalTable: "EducationObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEducationLists_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEducationLists_EducationObjectId",
                table: "UserEducationLists",
                column: "EducationObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEducationLists");
        }
    }
}

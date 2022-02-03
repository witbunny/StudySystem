using Microsoft.EntityFrameworkCore.Migrations;

namespace cprocess.Migrations
{
    public partial class altertableNamemajorteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EfMajor_EfTeacher_TeacherId",
                table: "EfMajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EfTeacher",
                table: "EfTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EfMajor",
                table: "EfMajor");

            migrationBuilder.RenameTable(
                name: "EfTeacher",
                newName: "EF_Teacher");

            migrationBuilder.RenameTable(
                name: "EfMajor",
                newName: "EF_Major");

            migrationBuilder.RenameIndex(
                name: "IX_EfMajor_TeacherId",
                table: "EF_Major",
                newName: "IX_EF_Major_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EF_Teacher",
                table: "EF_Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EF_Major",
                table: "EF_Major",
                column: "EfMajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EF_Major_EF_Teacher_TeacherId",
                table: "EF_Major",
                column: "TeacherId",
                principalTable: "EF_Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EF_Major_EF_Teacher_TeacherId",
                table: "EF_Major");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EF_Teacher",
                table: "EF_Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EF_Major",
                table: "EF_Major");

            migrationBuilder.RenameTable(
                name: "EF_Teacher",
                newName: "EfTeacher");

            migrationBuilder.RenameTable(
                name: "EF_Major",
                newName: "EfMajor");

            migrationBuilder.RenameIndex(
                name: "IX_EF_Major_TeacherId",
                table: "EfMajor",
                newName: "IX_EfMajor_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EfTeacher",
                table: "EfTeacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EfMajor",
                table: "EfMajor",
                column: "EfMajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EfMajor_EfTeacher_TeacherId",
                table: "EfMajor",
                column: "TeacherId",
                principalTable: "EfTeacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

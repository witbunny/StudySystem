using Microsoft.EntityFrameworkCore.Migrations;

namespace cprocess.Migrations
{
    public partial class altercolumnNamestudentmajor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EF_Student",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "EfMajorId",
                table: "EF_Major",
                newName: "MajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "EF_Student",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MajorId",
                table: "EF_Major",
                newName: "EfMajorId");
        }
    }
}

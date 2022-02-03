using Microsoft.EntityFrameworkCore.Migrations;

namespace cprocess.Migrations
{
    public partial class alterstudentindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EF_Student_StudentName",
                table: "EF_Student",
                column: "StudentName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EF_Student_StudentName",
                table: "EF_Student");
        }
    }
}

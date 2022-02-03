using Microsoft.EntityFrameworkCore.Migrations;

namespace cprocess.Migrations
{
    public partial class addstudentOncall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Oncall",
                table: "EF_Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oncall",
                table: "EF_Student");
        }
    }
}

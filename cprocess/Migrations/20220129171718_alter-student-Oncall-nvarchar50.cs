using Microsoft.EntityFrameworkCore.Migrations;

namespace cprocess.Migrations
{
    public partial class alterstudentOncallnvarchar50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Oncall",
                table: "EF_Student",
                type: "NVARCHAR(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Oncall",
                table: "EF_Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldNullable: true);
        }
    }
}

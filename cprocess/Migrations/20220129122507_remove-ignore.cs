using Microsoft.EntityFrameworkCore.Migrations;

namespace cprocess.Migrations
{
    public partial class removeignore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Difficulty",
                table: "EfMajor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "EfMajor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EfTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfTeacher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EfMajor_TeacherId",
                table: "EfMajor",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_EfMajor_EfTeacher_TeacherId",
                table: "EfMajor",
                column: "TeacherId",
                principalTable: "EfTeacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EfMajor_EfTeacher_TeacherId",
                table: "EfMajor");

            migrationBuilder.DropTable(
                name: "EfTeacher");

            migrationBuilder.DropIndex(
                name: "IX_EfMajor_TeacherId",
                table: "EfMajor");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "EfMajor");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "EfMajor");
        }
    }
}

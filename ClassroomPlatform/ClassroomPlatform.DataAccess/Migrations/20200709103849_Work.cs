using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassroomPlatform.DataAccess.Migrations
{
    public partial class Work : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Work",
                table: "EndUserGrades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Work",
                table: "EndUserGrades");
        }
    }
}

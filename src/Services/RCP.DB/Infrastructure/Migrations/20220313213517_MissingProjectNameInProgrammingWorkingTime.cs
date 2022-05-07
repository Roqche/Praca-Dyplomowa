using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCP.DB.Infrastructure.Migrations
{
    public partial class MissingProjectNameInProgrammingWorkingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "ProgrammerWorkingTime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "ProgrammerWorkingTime");
        }
    }
}

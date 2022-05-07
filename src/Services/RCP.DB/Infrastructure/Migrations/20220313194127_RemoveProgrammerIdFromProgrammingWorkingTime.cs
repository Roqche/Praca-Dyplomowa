using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCP.DB.Infrastructure.Migrations
{
    public partial class RemoveProgrammerIdFromProgrammingWorkingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
                table: "ProgrammerWorkingTime");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammerWorkingTime_ProgrammerId",
                table: "ProgrammerWorkingTime");

            migrationBuilder.DropColumn(
                name: "ProgrammerId",
                table: "ProgrammerWorkingTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammerId",
                table: "ProgrammerWorkingTime",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammerWorkingTime_ProgrammerId",
                table: "ProgrammerWorkingTime",
                column: "ProgrammerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
                table: "ProgrammerWorkingTime",
                column: "ProgrammerId",
                principalTable: "Programmer",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCP.DB.Infrastructure.Migrations
{
    public partial class SaveLoginToProgrammingWorkingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
                table: "ProgrammerWorkingTime");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammerId",
                table: "ProgrammerWorkingTime",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "ProgrammerWorkingTime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
                table: "ProgrammerWorkingTime",
                column: "ProgrammerId",
                principalTable: "Programmer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
                table: "ProgrammerWorkingTime");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "ProgrammerWorkingTime");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammerId",
                table: "ProgrammerWorkingTime",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
                table: "ProgrammerWorkingTime",
                column: "ProgrammerId",
                principalTable: "Programmer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

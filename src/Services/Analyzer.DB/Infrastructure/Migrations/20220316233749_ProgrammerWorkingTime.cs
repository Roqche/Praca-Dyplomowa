using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.DB.Infrastructure.Migrations
{
    public partial class ProgrammerWorkingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammerWorkingTime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProgrammerId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammerWorkingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
                        column: x => x.ProgrammerId,
                        principalTable: "Programmer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProgrammerWorkingTime_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammerWorkingTime_ProgrammerId",
                table: "ProgrammerWorkingTime",
                column: "ProgrammerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammerWorkingTime_ProjectId",
                table: "ProgrammerWorkingTime",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammerWorkingTime");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RCP.DB.Infrastructure.Migrations
{
	public partial class ProgrammerWorkingTimeInitial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateSequence(
				name: "programmer_working_time_hilo",
				incrementBy: 10);

			migrationBuilder.AddColumn<string>(
				name: "ProjectName",
				table: "JenkinsJob",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.CreateTable(
				name: "ProgrammerWorkingTime",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false),
					ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ProgrammerLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Time = table.Column<double>(type: "float", nullable: false),
					Date = table.Column<DateTime>(type: "date", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProgrammerWorkingTime", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ProgrammerWorkingTime");

			migrationBuilder.DropSequence(
				name: "programmer_working_time_hilo");

			migrationBuilder.DropColumn(
				name: "ProjectName",
				table: "JenkinsJob");
		}
	}
}

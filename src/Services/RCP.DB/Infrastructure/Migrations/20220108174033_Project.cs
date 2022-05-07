using Microsoft.EntityFrameworkCore.Migrations;

namespace RCP.DB.Infrastructure.Migrations
{
	public partial class Project : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ProjectName",
				table: "ProgrammerWorkingTime");

			migrationBuilder.DropColumn(
				name: "ProjectName",
				table: "JenkinsJob");

			migrationBuilder.CreateSequence(
				name: "project_hilo",
				incrementBy: 10);

			migrationBuilder.AddColumn<int>(
				name: "ProjectId",
				table: "ProgrammerWorkingTime",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "ProjectId",
				table: "JenkinsJob",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateTable(
				name: "Project",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Project", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ProgrammerWorkingTime_ProjectId",
				table: "ProgrammerWorkingTime",
				column: "ProjectId");

			migrationBuilder.CreateIndex(
				name: "IX_JenkinsJob_ProjectId",
				table: "JenkinsJob",
				column: "ProjectId");

			migrationBuilder.AddForeignKey(
				name: "FK_JenkinsJob_Project_ProjectId",
				table: "JenkinsJob",
				column: "ProjectId",
				principalTable: "Project",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ProgrammerWorkingTime_Project_ProjectId",
				table: "ProgrammerWorkingTime",
				column: "ProjectId",
				principalTable: "Project",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_JenkinsJob_Project_ProjectId",
				table: "JenkinsJob");

			migrationBuilder.DropForeignKey(
				name: "FK_ProgrammerWorkingTime_Project_ProjectId",
				table: "ProgrammerWorkingTime");

			migrationBuilder.DropTable(
				name: "Project");

			migrationBuilder.DropIndex(
				name: "IX_ProgrammerWorkingTime_ProjectId",
				table: "ProgrammerWorkingTime");

			migrationBuilder.DropIndex(
				name: "IX_JenkinsJob_ProjectId",
				table: "JenkinsJob");

			migrationBuilder.DropSequence(
				name: "project_hilo");

			migrationBuilder.DropColumn(
				name: "ProjectId",
				table: "ProgrammerWorkingTime");

			migrationBuilder.DropColumn(
				name: "ProjectId",
				table: "JenkinsJob");

			migrationBuilder.AddColumn<string>(
				name: "ProjectName",
				table: "ProgrammerWorkingTime",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "ProjectName",
				table: "JenkinsJob",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}
	}
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCP.DB.Infrastructure.Migrations
{
	public partial class JenkinsJobWithoutDependencies : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_JenkinsJob_Project_ProjectId",
				table: "JenkinsJob");

			migrationBuilder.DropIndex(
				name: "IX_JenkinsJob_ProjectId",
				table: "JenkinsJob");

			migrationBuilder.DropColumn(
				name: "ProjectId",
				table: "JenkinsJob");

			migrationBuilder.AddColumn<string>(
				name: "ProjectName",
				table: "JenkinsJob",
				type: "nvarchar(max)",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ProjectName",
				table: "JenkinsJob");

			migrationBuilder.AddColumn<int>(
				name: "ProjectId",
				table: "JenkinsJob",
				type: "int",
				nullable: false,
				defaultValue: 0);

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
		}
	}
}

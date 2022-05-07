using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RCP.DB.Infrastructure.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateSequence(
				name: "jenkins_job_hilo",
				incrementBy: 10);

			migrationBuilder.CreateTable(
				name: "JenkinsJob",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false),
					JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					BuildNumber = table.Column<int>(type: "int", nullable: false),
					Culprit = table.Column<string>(type: "nvarchar(max)", nullable: true),
					BuildTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					Duration = table.Column<int>(type: "int", nullable: false),
					Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
					EstimatedDuration = table.Column<int>(type: "int", nullable: false),
					Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_JenkinsJob", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "JenkinsJob");

			migrationBuilder.DropSequence(
				name: "jenkins_job_hilo");
		}
	}
}

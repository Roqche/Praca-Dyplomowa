using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Analyzer.DB.Infrastructure.Migrations
{
	public partial class SpecialMoments : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateSequence(
				name: "connector_used_in_project_hilo",
				incrementBy: 10);

			migrationBuilder.CreateSequence(
				name: "project_hilo",
				incrementBy: 10);

			migrationBuilder.CreateTable(
				name: "Project",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false),
					ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Project", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "ConnectorUsedInProject",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false),
					Connector = table.Column<int>(type: "int", nullable: false),
					ProjectId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ConnectorUsedInProject", x => x.Id);
					table.ForeignKey(
						name: "FK_ConnectorUsedInProject_Project_ProjectId",
						column: x => x.ProjectId,
						principalTable: "Project",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SpecialMoment",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Context = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Appeared = table.Column<DateTime>(type: "datetime2", nullable: false),
					ProjectId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SpecialMoment", x => x.Id);
					table.ForeignKey(
						name: "FK_SpecialMoment_Project_ProjectId",
						column: x => x.ProjectId,
						principalTable: "Project",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ConnectorUsedInProject_ProjectId",
				table: "ConnectorUsedInProject",
				column: "ProjectId");

			migrationBuilder.CreateIndex(
				name: "IX_SpecialMoment_ProjectId",
				table: "SpecialMoment",
				column: "ProjectId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ConnectorUsedInProject");

			migrationBuilder.DropTable(
				name: "SpecialMoment");

			migrationBuilder.DropTable(
				name: "Project");

			migrationBuilder.DropSequence(
				name: "connector_used_in_project_hilo");

			migrationBuilder.DropSequence(
				name: "project_hilo");
		}
	}
}

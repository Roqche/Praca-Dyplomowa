using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Analyzer.DB.Infrastructure.Migrations
{
	public partial class PipelineExecution : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "PipelineContext",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Context = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PipelineContext", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Programmer",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
					FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ProjectId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Programmer", x => x.Id);
					table.ForeignKey(
						name: "FK_Programmer_Project_ProjectId",
						column: x => x.ProjectId,
						principalTable: "Project",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "PipelineExecution",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ContextId = table.Column<int>(type: "int", nullable: false),
					ProgrammerId = table.Column<int>(type: "int", nullable: false),
					ProjectId = table.Column<int>(type: "int", nullable: false),
					Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ExecutionNumber = table.Column<int>(type: "int", nullable: false),
					StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					Duration = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PipelineExecution", x => x.Id);
					table.ForeignKey(
						name: "FK_PipelineExecution_PipelineContext_ContextId",
						column: x => x.ContextId,
						principalTable: "PipelineContext",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_PipelineExecution_Programmer_ProgrammerId",
						column: x => x.ProgrammerId,
						principalTable: "Programmer",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_PipelineExecution_Project_ProjectId",
						column: x => x.ProjectId,
						principalTable: "Project",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_PipelineExecution_ContextId",
				table: "PipelineExecution",
				column: "ContextId");

			migrationBuilder.CreateIndex(
				name: "IX_PipelineExecution_ProgrammerId",
				table: "PipelineExecution",
				column: "ProgrammerId");

			migrationBuilder.CreateIndex(
				name: "IX_PipelineExecution_ProjectId",
				table: "PipelineExecution",
				column: "ProjectId");

			migrationBuilder.CreateIndex(
				name: "IX_Programmer_ProjectId",
				table: "Programmer",
				column: "ProjectId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PipelineExecution");

			migrationBuilder.DropTable(
				name: "PipelineContext");

			migrationBuilder.DropTable(
				name: "Programmer");
		}
	}
}

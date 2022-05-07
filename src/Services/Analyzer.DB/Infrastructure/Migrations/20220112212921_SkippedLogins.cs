using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.DB.Infrastructure.Migrations
{
	public partial class SkippedLogins : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "SkippedLogin",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ProjectId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SkippedLogin", x => x.Id);
					table.ForeignKey(
						name: "FK_SkippedLogin_Project_ProjectId",
						column: x => x.ProjectId,
						principalTable: "Project",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_SkippedLogin_ProjectId",
				table: "SkippedLogin",
				column: "ProjectId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "SkippedLogin");
		}
	}
}

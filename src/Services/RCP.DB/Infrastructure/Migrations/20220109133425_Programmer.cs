using Microsoft.EntityFrameworkCore.Migrations;

namespace RCP.DB.Infrastructure.Migrations
{
	public partial class Programmer : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_ProgrammerWorkingTime_Project_ProjectId",
				table: "ProgrammerWorkingTime");

			migrationBuilder.DropColumn(
				name: "ProgrammerLogin",
				table: "ProgrammerWorkingTime");

			migrationBuilder.RenameColumn(
				name: "ProjectId",
				table: "ProgrammerWorkingTime",
				newName: "ProgrammerId");

			migrationBuilder.RenameIndex(
				name: "IX_ProgrammerWorkingTime_ProjectId",
				table: "ProgrammerWorkingTime",
				newName: "IX_ProgrammerWorkingTime_ProgrammerId");

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

			migrationBuilder.CreateIndex(
				name: "IX_Programmer_ProjectId",
				table: "Programmer",
				column: "ProjectId");

			migrationBuilder.AddForeignKey(
				name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
				table: "ProgrammerWorkingTime",
				column: "ProgrammerId",
				principalTable: "Programmer",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_ProgrammerWorkingTime_Programmer_ProgrammerId",
				table: "ProgrammerWorkingTime");

			migrationBuilder.DropTable(
				name: "Programmer");

			migrationBuilder.RenameColumn(
				name: "ProgrammerId",
				table: "ProgrammerWorkingTime",
				newName: "ProjectId");

			migrationBuilder.RenameIndex(
				name: "IX_ProgrammerWorkingTime_ProgrammerId",
				table: "ProgrammerWorkingTime",
				newName: "IX_ProgrammerWorkingTime_ProjectId");

			migrationBuilder.AddColumn<string>(
				name: "ProgrammerLogin",
				table: "ProgrammerWorkingTime",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddForeignKey(
				name: "FK_ProgrammerWorkingTime_Project_ProjectId",
				table: "ProgrammerWorkingTime",
				column: "ProjectId",
				principalTable: "Project",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.DB.Infrastructure.Migrations
{
    public partial class AddProjectIdToPipelineContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PipelineContext_Project_ProjectId",
                table: "PipelineContext");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "PipelineContext",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PipelineContext_Project_ProjectId",
                table: "PipelineContext",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PipelineContext_Project_ProjectId",
                table: "PipelineContext");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "PipelineContext",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PipelineContext_Project_ProjectId",
                table: "PipelineContext",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}

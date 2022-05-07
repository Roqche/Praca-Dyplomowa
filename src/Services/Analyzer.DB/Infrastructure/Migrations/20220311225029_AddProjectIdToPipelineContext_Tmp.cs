using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.DB.Infrastructure.Migrations
{
    public partial class AddProjectIdToPipelineContext_Tmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PipelineContext",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PipelineContext_ProjectId",
                table: "PipelineContext",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_PipelineContext_Project_ProjectId",
                table: "PipelineContext",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PipelineContext_Project_ProjectId",
                table: "PipelineContext");

            migrationBuilder.DropIndex(
                name: "IX_PipelineContext_ProjectId",
                table: "PipelineContext");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PipelineContext");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.DB.Infrastructure.Migrations
{
    public partial class AddContextIdToSpecialMoment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialMoment_Project_ProjectId",
                table: "SpecialMoment");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "SpecialMoment");

            migrationBuilder.AddColumn<int>(
                name: "ContextId",
                table: "SpecialMoment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialMoment_ContextId",
                table: "SpecialMoment",
                column: "ContextId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialMoment_PipelineContext_ContextId",
                table: "SpecialMoment",
                column: "ContextId",
                principalTable: "PipelineContext",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialMoment_Project_ProjectId",
                table: "SpecialMoment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialMoment_PipelineContext_ContextId",
                table: "SpecialMoment");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialMoment_Project_ProjectId",
                table: "SpecialMoment");

            migrationBuilder.DropIndex(
                name: "IX_SpecialMoment_ContextId",
                table: "SpecialMoment");

            migrationBuilder.DropColumn(
                name: "ContextId",
                table: "SpecialMoment");

            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "SpecialMoment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialMoment_Project_ProjectId",
                table: "SpecialMoment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

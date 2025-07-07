using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectArte.Migrations
{
    /// <inheritdoc />
    public partial class WorksAssId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopAssistants_Assistants_AssistantId1",
                table: "WorkshopAssistants");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopAssistants_AssistantId1",
                table: "WorkshopAssistants");

            migrationBuilder.DropColumn(
                name: "AssistantId1",
                table: "WorkshopAssistants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssistantId1",
                table: "WorkshopAssistants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopAssistants_AssistantId1",
                table: "WorkshopAssistants",
                column: "AssistantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopAssistants_Assistants_AssistantId1",
                table: "WorkshopAssistants",
                column: "AssistantId1",
                principalTable: "Assistants",
                principalColumn: "Id");
        }
    }
}

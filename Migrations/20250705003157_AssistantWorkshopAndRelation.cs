using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectArte.Migrations
{
    /// <inheritdoc />
    public partial class AssistantWorkshopAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistants_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workshops_Rooms_RoomName",
                        column: x => x.RoomName,
                        principalTable: "Rooms",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workshops_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopAssistants",
                columns: table => new
                {
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    AssistantId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    AssistantId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopAssistants", x => new { x.WorkshopId, x.AssistantId });
                    table.ForeignKey(
                        name: "FK_WorkshopAssistants_Assistants_AssistantId",
                        column: x => x.AssistantId,
                        principalTable: "Assistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopAssistants_Assistants_AssistantId1",
                        column: x => x.AssistantId1,
                        principalTable: "Assistants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkshopAssistants_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_CenterId",
                table: "Assistants",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopAssistants_AssistantId",
                table: "WorkshopAssistants",
                column: "AssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopAssistants_AssistantId1",
                table: "WorkshopAssistants",
                column: "AssistantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_RoomName",
                table: "Workshops",
                column: "RoomName");

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_TeacherId",
                table: "Workshops",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopAssistants");

            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectArte.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRoom_Resources_ResourceId",
                table: "ResourceRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRoom_Rooms_RoomName",
                table: "ResourceRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceRoom",
                table: "ResourceRoom");

            migrationBuilder.RenameTable(
                name: "ResourceRoom",
                newName: "ResourceRooms");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceRoom_RoomName",
                table: "ResourceRooms",
                newName: "IX_ResourceRooms_RoomName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceRooms",
                table: "ResourceRooms",
                columns: new[] { "ResourceId", "RoomName" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRooms_Resources_ResourceId",
                table: "ResourceRooms",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRooms_Rooms_RoomName",
                table: "ResourceRooms",
                column: "RoomName",
                principalTable: "Rooms",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRooms_Resources_ResourceId",
                table: "ResourceRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRooms_Rooms_RoomName",
                table: "ResourceRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceRooms",
                table: "ResourceRooms");

            migrationBuilder.RenameTable(
                name: "ResourceRooms",
                newName: "ResourceRoom");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceRooms_RoomName",
                table: "ResourceRoom",
                newName: "IX_ResourceRoom_RoomName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceRoom",
                table: "ResourceRoom",
                columns: new[] { "ResourceId", "RoomName" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRoom_Resources_ResourceId",
                table: "ResourceRoom",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRoom_Rooms_RoomName",
                table: "ResourceRoom",
                column: "RoomName",
                principalTable: "Rooms",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

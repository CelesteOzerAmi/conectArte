using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conectArte.Migrations
{
    /// <inheritdoc />
    public partial class ResourceRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRoom_Resources_AssignedResourcesId",
                table: "ResourceRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRoom_Rooms_AssignedRoomsName",
                table: "ResourceRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceRoom",
                table: "ResourceRoom");

            migrationBuilder.RenameColumn(
                name: "AssignedRoomsName",
                table: "ResourceRoom",
                newName: "RoomName");

            migrationBuilder.RenameColumn(
                name: "AssignedResourcesId",
                table: "ResourceRoom",
                newName: "ResourceCount");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceRoom_AssignedRoomsName",
                table: "ResourceRoom",
                newName: "IX_ResourceRoom_RoomName");

            migrationBuilder.AddColumn<int>(
                name: "ResourceId",
                table: "ResourceRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "ResourceRoom");

            migrationBuilder.RenameColumn(
                name: "ResourceCount",
                table: "ResourceRoom",
                newName: "AssignedResourcesId");

            migrationBuilder.RenameColumn(
                name: "RoomName",
                table: "ResourceRoom",
                newName: "AssignedRoomsName");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceRoom_RoomName",
                table: "ResourceRoom",
                newName: "IX_ResourceRoom_AssignedRoomsName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceRoom",
                table: "ResourceRoom",
                columns: new[] { "AssignedResourcesId", "AssignedRoomsName" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRoom_Resources_AssignedResourcesId",
                table: "ResourceRoom",
                column: "AssignedResourcesId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRoom_Rooms_AssignedRoomsName",
                table: "ResourceRoom",
                column: "AssignedRoomsName",
                principalTable: "Rooms",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

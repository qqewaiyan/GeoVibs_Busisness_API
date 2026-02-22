using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoVibs_Busisness_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_session_details_sessions_session_id",
                table: "session_details");

            migrationBuilder.DropForeignKey(
                name: "FK_sessions_rooms_room_id",
                table: "sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_levels_user_level_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venues",
                table: "venues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_levels",
                table: "user_levels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sessions",
                table: "sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_session_details",
                table: "session_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.RenameTable(
                name: "venues",
                newName: "Venue");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "user_levels",
                newName: "User_level");

            migrationBuilder.RenameTable(
                name: "sessions",
                newName: "Session");

            migrationBuilder.RenameTable(
                name: "session_details",
                newName: "Session_Detail");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_venues_name",
                table: "Venue",
                newName: "IX_Venue_name");

            migrationBuilder.RenameIndex(
                name: "IX_users_venue_id_email",
                table: "User",
                newName: "IX_User_venue_id_email");

            migrationBuilder.RenameIndex(
                name: "IX_users_user_level_id",
                table: "User",
                newName: "IX_User_user_level_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_levels_name",
                table: "User_level",
                newName: "IX_User_level_name");

            migrationBuilder.RenameIndex(
                name: "IX_sessions_venue_id_status",
                table: "Session",
                newName: "IX_Session_venue_id_status");

            migrationBuilder.RenameIndex(
                name: "IX_sessions_room_id",
                table: "Session",
                newName: "IX_Session_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_session_details_venue_id_session_id",
                table: "Session_Detail",
                newName: "IX_Session_Detail_venue_id_session_id");

            migrationBuilder.RenameIndex(
                name: "IX_session_details_session_id",
                table: "Session_Detail",
                newName: "IX_Session_Detail_session_id");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_venue_id_status",
                table: "Room",
                newName: "IX_Room_venue_id_status");

            migrationBuilder.RenameIndex(
                name: "IX_items_venue_id_name",
                table: "Item",
                newName: "IX_Item_venue_id_name");

            migrationBuilder.RenameIndex(
                name: "IX_items_venue_id",
                table: "Item",
                newName: "IX_Item_venue_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venue",
                table: "Venue",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_level",
                table: "User_level",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session_Detail",
                table: "Session_Detail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Room_room_id",
                table: "Session",
                column: "room_id",
                principalTable: "Room",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Detail_Session_session_id",
                table: "Session_Detail",
                column: "session_id",
                principalTable: "Session",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_level_user_level_id",
                table: "User",
                column: "user_level_id",
                principalTable: "User_level",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Room_room_id",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Detail_Session_session_id",
                table: "Session_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_level_user_level_id",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venue",
                table: "Venue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_level",
                table: "User_level");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session_Detail",
                table: "Session_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Venue",
                newName: "venues");

            migrationBuilder.RenameTable(
                name: "User_level",
                newName: "user_levels");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Session_Detail",
                newName: "session_details");

            migrationBuilder.RenameTable(
                name: "Session",
                newName: "sessions");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "items");

            migrationBuilder.RenameIndex(
                name: "IX_Venue_name",
                table: "venues",
                newName: "IX_venues_name");

            migrationBuilder.RenameIndex(
                name: "IX_User_level_name",
                table: "user_levels",
                newName: "IX_user_levels_name");

            migrationBuilder.RenameIndex(
                name: "IX_User_venue_id_email",
                table: "users",
                newName: "IX_users_venue_id_email");

            migrationBuilder.RenameIndex(
                name: "IX_User_user_level_id",
                table: "users",
                newName: "IX_users_user_level_id");

            migrationBuilder.RenameIndex(
                name: "IX_Session_Detail_venue_id_session_id",
                table: "session_details",
                newName: "IX_session_details_venue_id_session_id");

            migrationBuilder.RenameIndex(
                name: "IX_Session_Detail_session_id",
                table: "session_details",
                newName: "IX_session_details_session_id");

            migrationBuilder.RenameIndex(
                name: "IX_Session_venue_id_status",
                table: "sessions",
                newName: "IX_sessions_venue_id_status");

            migrationBuilder.RenameIndex(
                name: "IX_Session_room_id",
                table: "sessions",
                newName: "IX_sessions_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_Room_venue_id_status",
                table: "rooms",
                newName: "IX_rooms_venue_id_status");

            migrationBuilder.RenameIndex(
                name: "IX_Item_venue_id_name",
                table: "items",
                newName: "IX_items_venue_id_name");

            migrationBuilder.RenameIndex(
                name: "IX_Item_venue_id",
                table: "items",
                newName: "IX_items_venue_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_venues",
                table: "venues",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_levels",
                table: "user_levels",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_session_details",
                table: "session_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sessions",
                table: "sessions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rooms",
                table: "rooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_session_details_sessions_session_id",
                table: "session_details",
                column: "session_id",
                principalTable: "sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sessions_rooms_room_id",
                table: "sessions",
                column: "room_id",
                principalTable: "rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_levels_user_level_id",
                table: "users",
                column: "user_level_id",
                principalTable: "user_levels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

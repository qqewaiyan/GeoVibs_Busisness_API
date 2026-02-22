using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoVibs_Busisness_API.Migrations
{
    /// <inheritdoc />
    public partial class RemovePermissionColumnInUserLevelEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "can_manage_room",
                table: "User_level");

            migrationBuilder.DropColumn(
                name: "can_manage_session",
                table: "User_level");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "can_manage_room",
                table: "User_level",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "can_manage_session",
                table: "User_level",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

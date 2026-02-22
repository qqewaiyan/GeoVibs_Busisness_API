using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoVibs_Busisness_API.Migrations
{
    /// <inheritdoc />
    public partial class InactiveFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "User",
                newName: "in_active");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Movies",
                newName: "InActive");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Item",
                newName: "in_active");

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Venue",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "venue_id",
                table: "User_level",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "feature",
                table: "Room",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "in_active",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "venue_id",
                table: "User_level");

            migrationBuilder.DropColumn(
                name: "name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "feature",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "in_active",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "in_active",
                table: "User",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "InActive",
                table: "Movies",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "in_active",
                table: "Item",
                newName: "is_active");
        }
    }
}

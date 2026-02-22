using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoVibs_Busisness_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "items");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "items",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "items",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "items",
                newName: "venue_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "items",
                newName: "is_active");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_items_venue_id",
                table: "items",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_items_venue_id_name",
                table: "items",
                columns: new[] { "venue_id", "name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_venue_id",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_venue_id_name",
                table: "items");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Items",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "venue_id",
                table: "Items",
                newName: "VenueId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Items",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");
        }
    }
}

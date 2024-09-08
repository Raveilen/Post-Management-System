using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostOfficeCapacityFeatureRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "packageLCapacity",
                table: "PostOffices");

            migrationBuilder.DropColumn(
                name: "packageMCapacity",
                table: "PostOffices");

            migrationBuilder.DropColumn(
                name: "packageSCapacity",
                table: "PostOffices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "packageLCapacity",
                table: "PostOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "packageMCapacity",
                table: "PostOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "packageSCapacity",
                table: "PostOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

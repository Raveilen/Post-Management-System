using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablesFieldsChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.RenameColumn(
           name: "Dimensions",
           table: "PackageTypes",
           newName: "MaxDimensions");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.RenameColumn(
           name: "Dimensions",
           table: "PackageTypes",
           newName: "MaxDimensions");

        }
    }
}

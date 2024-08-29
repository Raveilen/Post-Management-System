using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class DbInitializerModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_ReceiverPostOfficePostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_SenderPostOfficePostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageTypes_TypePackageTypeID",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "HashCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HashCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "HashCode",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Statuses",
                newName: "StatusID");

            migrationBuilder.RenameColumn(
                name: "TypePackageTypeID",
                table: "Packages",
                newName: "PackageTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_TypePackageTypeID",
                table: "Packages",
                newName: "IX_Packages_PackageTypeID");

            migrationBuilder.RenameColumn(
                name: "SenderPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "SenderPostOfficeID");

            migrationBuilder.RenameColumn(
                name: "ReceiverPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "ReceiverPostOfficeID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_SenderPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_SenderPostOfficeID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_ReceiverPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_ReceiverPostOfficeID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Cities",
                newName: "CityID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Addresses",
                newName: "AddressID");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Statuses",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<bool>(
                name: "IsFragile",
                table: "PackageTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_PostOffices_ReceiverPostOfficeID",
                table: "Deliveries",
                column: "ReceiverPostOfficeID",
                principalTable: "PostOffices",
                principalColumn: "PostOfficeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_PostOffices_SenderPostOfficeID",
                table: "Deliveries",
                column: "SenderPostOfficeID",
                principalTable: "PostOffices",
                principalColumn: "PostOfficeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageTypes_PackageTypeID",
                table: "Packages",
                column: "PackageTypeID",
                principalTable: "PackageTypes",
                principalColumn: "PackageTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_ReceiverPostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_SenderPostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageTypes_PackageTypeID",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "IsFragile",
                table: "PackageTypes");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Statuses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PackageTypeID",
                table: "Packages",
                newName: "TypePackageTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_PackageTypeID",
                table: "Packages",
                newName: "IX_Packages_TypePackageTypeID");

            migrationBuilder.RenameColumn(
                name: "SenderPostOfficeID",
                table: "Deliveries",
                newName: "SenderPostOfficePostOfficeID");

            migrationBuilder.RenameColumn(
                name: "ReceiverPostOfficeID",
                table: "Deliveries",
                newName: "ReceiverPostOfficePostOfficeID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_SenderPostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_SenderPostOfficePostOfficeID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_ReceiverPostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_ReceiverPostOfficePostOfficeID");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Cities",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Addresses",
                newName: "ID");

            migrationBuilder.AddColumn<long>(
                name: "HashCode",
                table: "Customers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HashCode",
                table: "Cities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HashCode",
                table: "Addresses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_PostOffices_ReceiverPostOfficePostOfficeID",
                table: "Deliveries",
                column: "ReceiverPostOfficePostOfficeID",
                principalTable: "PostOffices",
                principalColumn: "PostOfficeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_PostOffices_SenderPostOfficePostOfficeID",
                table: "Deliveries",
                column: "SenderPostOfficePostOfficeID",
                principalTable: "PostOffices",
                principalColumn: "PostOfficeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageTypes_TypePackageTypeID",
                table: "Packages",
                column: "TypePackageTypeID",
                principalTable: "PackageTypes",
                principalColumn: "PackageTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

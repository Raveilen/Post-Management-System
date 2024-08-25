using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PackageTypePictAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_ReceiverPostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_SenderPostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Statuses_StatusID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_ReceiverID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_SenderID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageTypes_TypeID",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PostOffices",
                newName: "PostOfficeID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PackageTypes",
                newName: "PackageTypeID");

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "Packages",
                newName: "TypePackageTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_TypeID",
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

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Deliveries",
                newName: "DeliveryID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_SenderPostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_SenderPostOfficePostOfficeID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_ReceiverPostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_ReceiverPostOfficePostOfficeID");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PackageTypes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityID",
                table: "Addresses",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Deliveries_Statuses_StatusID",
                table: "Deliveries",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_ReceiverID",
                table: "Packages",
                column: "ReceiverID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_SenderID",
                table: "Packages",
                column: "SenderID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageTypes_TypePackageTypeID",
                table: "Packages",
                column: "TypePackageTypeID",
                principalTable: "PackageTypes",
                principalColumn: "PackageTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_ReceiverPostOfficePostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_PostOffices_SenderPostOfficePostOfficeID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Statuses_StatusID",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_ReceiverID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_SenderID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageTypes_TypePackageTypeID",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "PackageTypes");

            migrationBuilder.RenameColumn(
                name: "PostOfficeID",
                table: "PostOffices",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PackageTypeID",
                table: "PackageTypes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TypePackageTypeID",
                table: "Packages",
                newName: "TypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_TypePackageTypeID",
                table: "Packages",
                newName: "IX_Packages_TypeID");

            migrationBuilder.RenameColumn(
                name: "SenderPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "SenderPostOfficeID");

            migrationBuilder.RenameColumn(
                name: "ReceiverPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "ReceiverPostOfficeID");

            migrationBuilder.RenameColumn(
                name: "DeliveryID",
                table: "Deliveries",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_SenderPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_SenderPostOfficeID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_ReceiverPostOfficePostOfficeID",
                table: "Deliveries",
                newName: "IX_Deliveries_ReceiverPostOfficeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityID",
                table: "Addresses",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_PostOffices_ReceiverPostOfficeID",
                table: "Deliveries",
                column: "ReceiverPostOfficeID",
                principalTable: "PostOffices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_PostOffices_SenderPostOfficeID",
                table: "Deliveries",
                column: "SenderPostOfficeID",
                principalTable: "PostOffices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Statuses_StatusID",
                table: "Deliveries",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_ReceiverID",
                table: "Packages",
                column: "ReceiverID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_SenderID",
                table: "Packages",
                column: "SenderID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageTypes_TypeID",
                table: "Packages",
                column: "TypeID",
                principalTable: "PackageTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

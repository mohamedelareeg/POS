using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_customers_suppliers_image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Warehouses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Suppliers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Categories",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49c024aa-b738-402e-9f65-f9c2aaea0625", "AQAAAAIAAYagAAAAEAOptGlXGbVecBZCxMQlbzmnjHmdYMPlGIB2fMkh8yB/eHUngVePjDrSzWwI7a7U7A==", "f6e80ac8-0275-48e1-80b8-f923096cb1a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d6915c0-dd59-47a0-975f-c9ab008d6975", "AQAAAAIAAYagAAAAEJbg+/bVypPunbwDEVVg6rvaPK9VMKrt0u02o8tv9gDLqoPM0VIbF9QYCEr84lDljg==", "c8b09045-3314-4724-95aa-dcc338d02cff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Customers");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Categories",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97bb16e5-fcca-4df2-9bfc-80df37151d47", "AQAAAAIAAYagAAAAEHjM6obSv1J8NgQsAhmCDrFxF9M48A2ajZK7ZTmrXxLIzXdebzKPq+nSNWjwM4OXBA==", "6a3b6534-a3b8-4867-876d-04e1af722e39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be2dbbcf-f808-41b6-aad8-84b587508f87", "AQAAAAIAAYagAAAAEPcOIQBuBqhveHaSlCi28LJdoCcW4QIdzjFKLTlNEGFpKv2DMwzaXouPAcBBZ3VoGw==", "c32e1853-e829-419a-a682-92d9831f1893" });
        }
    }
}

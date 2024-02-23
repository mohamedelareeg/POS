using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sale_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "PurchaseProducts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3953a2ff-f710-48e3-9b03-20a02cb9028c", "AQAAAAIAAYagAAAAENhhpvPqv0vFLgIYkpNixdCZXs/cKn8SIzS9BSGklAhw7te0B4rZuvq4Fon8XvfCOg==", "f31ef7b0-76b7-47d2-bbe3-40039bcdfa1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2704723-c79e-4c5d-8a8e-d8240648feef", "AQAAAAIAAYagAAAAEFYUgCxHQFra0fQGa0F9aIOK1XUXK+IKJyrCykp6HFs4eNebXHPhBLht0ywzzgzK1A==", "704cf1e5-b455-4c77-8d3f-f8c0a9f4c45c" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "PurchaseProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5c4e014-99f4-4440-82ee-fc657a0114a4", "AQAAAAIAAYagAAAAEESBKUAXy2wq722O9LB3C/7KuTSn1bV35P8P0DE5NnlifkWiqUwFM/UyI1r0PYEOew==", "9d205876-4994-46e5-94ea-b82dd1ad2f32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bfc4a43-67b2-4d28-bc0f-8fa7c923e437", "AQAAAAIAAYagAAAAEGXQKCfEZttIS8mgfTUoqjFFkpfpbdY5Ep47PJ51ndeNaJLvl7cs5kjKrzN+Y0+Ltw==", "b5349955-b232-48b0-ae79-2f7fb704e3fb" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

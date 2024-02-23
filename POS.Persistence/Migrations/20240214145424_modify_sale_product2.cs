using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sale_product2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SaleProducts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca371ddf-26d9-48e5-92ec-dc16e2e3344c", "AQAAAAIAAYagAAAAEGyzbc8S2/mM5nzfC6PHw6b9+jzaBcHcRDMy0tYFujplo6wd5TOlAZy+Y9LrW9IOMw==", "46d42af8-cf89-455c-b1ff-edc2cc7bebe1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4f560c8-2869-4fed-944e-2ca665be5768", "AQAAAAIAAYagAAAAEK/0ZWp8DajTDGNh0Wo8oOzhzxUn62tp8CNSqZeIvYdBAq/5jw0gyd4Mc72ZLlDDKw==", "acfc827f-69ca-4177-aeb6-1679621a6cc5" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SaleProducts",
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
                values: new object[] { "3953a2ff-f710-48e3-9b03-20a02cb9028c", "AQAAAAIAAYagAAAAENhhpvPqv0vFLgIYkpNixdCZXs/cKn8SIzS9BSGklAhw7te0B4rZuvq4Fon8XvfCOg==", "f31ef7b0-76b7-47d2-bbe3-40039bcdfa1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2704723-c79e-4c5d-8a8e-d8240648feef", "AQAAAAIAAYagAAAAEFYUgCxHQFra0fQGa0F9aIOK1XUXK+IKJyrCykp6HFs4eNebXHPhBLht0ywzzgzK1A==", "704cf1e5-b455-4c77-8d3f-f8c0a9f4c45c" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

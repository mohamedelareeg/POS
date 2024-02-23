using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sale_product8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Earned",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "SalePrice");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa1e0a16-bb13-445c-8200-cd96ad19a64e", "AQAAAAIAAYagAAAAEJOx5BGh6NgZj6WppW0daLse8921rA27z6hyX6zR0GXnja7ksauoQtwjQoDqDKjmWQ==", "c3204854-f364-481d-b33f-081b2b089350" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b5ff87a-9223-4d34-9376-7b0378d4f1f9", "AQAAAAIAAYagAAAAENKzXVHYlx5XDHuJCZeTAAmN2eLVH9FIvt6eHDTtOaJ0X3zCkWcfhjjAc7cpvECEPw==", "9679b0f1-d0a5-40a3-b61c-e7d98b1e1c15" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Earned",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c74d9878-fc29-4b7f-a599-f29f58d24571", "AQAAAAIAAYagAAAAEDtXN2F+sSZ8xAtnCyrt+Me+XcvCMKPyCYxpP/se+EjrQXTIBJ4Dj5VLA1+TZlWUAQ==", "f83542fe-aa33-47e1-81dd-d76904a1aafb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ead13a31-56bd-487c-9deb-0f7f3d53bd79", "AQAAAAIAAYagAAAAEOd8zLA7hydMIMlkYgx5g0CoWC6p42J+oNa2GcdHVWSF8sPB5U4hjLY5iN9rGWKsbQ==", "be86d7fe-57d4-4fc9-be45-9db73a22169b" });
        }
    }
}

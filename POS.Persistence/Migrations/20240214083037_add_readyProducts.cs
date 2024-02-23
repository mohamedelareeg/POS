using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_readyProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadyProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadyProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReadyProductItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReadyProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadyProductItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadyProductItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadyProductItem_ReadyProduct_ReadyProductId",
                        column: x => x.ReadyProductId,
                        principalTable: "ReadyProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe5d2c14-81db-4066-a720-b751e722aead", "AQAAAAIAAYagAAAAEE5yBBgGHGwhROV3Ma/oJwmV0+fqBPEssziOKUW5wI9noxY+B8DtIZNSXbqddGqDpA==", "a862d017-1363-45fc-bf09-86d2fb526404" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f94e170b-4a66-467e-910f-0e1ac2c3d8d4", "AQAAAAIAAYagAAAAEPyKZvlNnj5yfSIVaAsS+M8zWllDYZzrKawN+iWkHrDUeBxTJ9tEMOyIRQdW/Z14aA==", "76c0e706-99b1-41ed-af58-2ac7d12b5e90" });

            migrationBuilder.CreateIndex(
                name: "IX_ReadyProductItem_ProductId",
                table: "ReadyProductItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadyProductItem_ReadyProductId",
                table: "ReadyProductItem",
                column: "ReadyProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadyProductItem");

            migrationBuilder.DropTable(
                name: "ReadyProduct");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51cd4980-cdff-445c-a5b0-e0c5dc0d96eb", "AQAAAAIAAYagAAAAEDM1KdyVxeX5RxOQBYhtNCzGXPUdac9J5sZ3WrL6C3FIHXhPb6mkAdyt9Lr+4jFq0g==", "909d8a17-15e2-48fb-b8ef-6551273d51fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09a031ff-5bf1-4728-ae16-de28c35203ab", "AQAAAAIAAYagAAAAELc3ifz5gi3Y7qBgWrDGEdoCtUW8NSYg4KTrkQQQ9qQTje1W8Uv4z/HPTNsfG9HZKQ==", "906cddfb-d931-4819-8233-590a7f4fffb1" });
        }
    }
}

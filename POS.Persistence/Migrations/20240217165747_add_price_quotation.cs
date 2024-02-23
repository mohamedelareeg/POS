using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_price_quotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Earned",
                table: "SaleProducts");

            migrationBuilder.CreateTable(
                name: "PriceQuotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceQuotations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true),
                    ReadyProductId = table.Column<int>(type: "INTEGER", nullable: true),
                    PriceQuotationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    SalePrice = table.Column<double>(type: "REAL", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotedProducts_PriceQuotations_PriceQuotationId",
                        column: x => x.PriceQuotationId,
                        principalTable: "PriceQuotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotedProducts_ReadyProducts_ReadyProductId",
                        column: x => x.ReadyProductId,
                        principalTable: "ReadyProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DefaultRole", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f0849b3-b137-48f0-b821-ef2b9d796e3c", "Administrator", "AQAAAAIAAYagAAAAEDFdz8f5eh6rF0L+vgvW4r0iygEkSIyqmvRjtZFrJruM1mgU1/uU+lbKN8D0fXln3Q==", "3d80f3f1-a426-4fa3-bc7e-5136dda6f950" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd875312-cce0-4285-917b-78d364ddf7e1", "AQAAAAIAAYagAAAAEDUtOM1pcq3LAluVEYwU5xYr/Are2oXem/1P2U40uQblDWHAxaXedQllOKdTXr7y3A==", "3841756b-ac8b-4705-9623-4d2aae5432ae" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotations_CustomerId",
                table: "PriceQuotations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotedProducts_PriceQuotationId",
                table: "QuotedProducts",
                column: "PriceQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotedProducts_ProductId",
                table: "QuotedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotedProducts_ReadyProductId",
                table: "QuotedProducts",
                column: "ReadyProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotedProducts");

            migrationBuilder.DropTable(
                name: "PriceQuotations");

            migrationBuilder.AddColumn<double>(
                name: "Earned",
                table: "SaleProducts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DefaultRole", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8068e01-5aed-496e-a647-6ffc954e5da1", null, "AQAAAAIAAYagAAAAEHpGAm+jySRO4gGxlSHCkO4cmM1Oen4jcrVbySvIW4IzNx9pRfpIHTBu3uVtXEelGg==", "948d8c12-b7c8-4478-8a47-93aa79487d69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "437d09e5-3ada-4251-bd5a-6ac528dde2d1", "AQAAAAIAAYagAAAAEB+ODJywihGvlCvERpGMuf5Tp2vbyZZfaRErZ+SmY3RF/FfnZNL0ReA5Q3qqBgNjWw==", "ce0b56ed-4558-4b4e-a0d2-eb03071928d6" });
        }
    }
}

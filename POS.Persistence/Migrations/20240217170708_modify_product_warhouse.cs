using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_product_warhouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "SaleProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "QuotedProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "PurchaseProducts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcd6024f-fe95-472a-982d-e06071df2996", "AQAAAAIAAYagAAAAEHsFBoYC1OjlTy3EMnR9xiQB+TrnU9HeuoZ31GQQZTW2KBUOnP/jk8KfVJJNbL/VhA==", "db70b73d-d4bd-4de1-95e5-bae2a3f3ab3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d5e8096-5f8a-4799-a39d-2c7cd7a0dc7d", "AQAAAAIAAYagAAAAEEjM5C7W9iWZ64QESgYCGDT/n8dUlCyZX6476LyDEcz2ZOsmo0xqcT6CEercmKzzcg==", "ed2b70b6-0f12-459e-862e-f4a8793037ac" });

            migrationBuilder.CreateIndex(
                name: "IX_SaleProducts_WarehouseId",
                table: "SaleProducts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotedProducts_WarehouseId",
                table: "QuotedProducts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_WarehouseId",
                table: "PurchaseProducts",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Warehouses_WarehouseId",
                table: "PurchaseProducts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotedProducts_Warehouses_WarehouseId",
                table: "QuotedProducts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Warehouses_WarehouseId",
                table: "SaleProducts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Warehouses_WarehouseId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotedProducts_Warehouses_WarehouseId",
                table: "QuotedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Warehouses_WarehouseId",
                table: "SaleProducts");

            migrationBuilder.DropIndex(
                name: "IX_SaleProducts_WarehouseId",
                table: "SaleProducts");

            migrationBuilder.DropIndex(
                name: "IX_QuotedProducts_WarehouseId",
                table: "QuotedProducts");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseProducts_WarehouseId",
                table: "PurchaseProducts");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "QuotedProducts");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "PurchaseProducts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f0849b3-b137-48f0-b821-ef2b9d796e3c", "AQAAAAIAAYagAAAAEDFdz8f5eh6rF0L+vgvW4r0iygEkSIyqmvRjtZFrJruM1mgU1/uU+lbKN8D0fXln3Q==", "3d80f3f1-a426-4fa3-bc7e-5136dda6f950" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd875312-cce0-4285-917b-78d364ddf7e1", "AQAAAAIAAYagAAAAEDUtOM1pcq3LAluVEYwU5xYr/Are2oXem/1P2U40uQblDWHAxaXedQllOKdTXr7y3A==", "3841756b-ac8b-4705-9623-4d2aae5432ae" });
        }
    }
}

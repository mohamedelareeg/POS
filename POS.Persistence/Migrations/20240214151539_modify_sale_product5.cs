using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sale_product5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Banks_BankId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Cashes_CashId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Cheques_ChequeId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_CreditCards_CreditCardId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Invoices_InvoiceId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Areas_AreaId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Shippings_ShippingId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Warehouses_WarehouseId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Banks_BankId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Cashes_CashId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Cheques_ChequeId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_CreditCards_CreditCardId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Purchases_PurchaseId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Products_ProductId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Shippings_ShippingId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Warehouses_WarehouseId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadyProductItems_Products_ProductId",
                table: "ReadyProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadyProductItems_ReadyProducts_ReadyProductId",
                table: "ReadyProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_ReadyProducts_ReadyProductId",
                table: "SaleProducts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076521d5-d31e-4f94-8e31-69b7bb76fb96", "AQAAAAIAAYagAAAAEEofhZ5DJV6JaYmh2UUqntDz6M/mnIkgWeg5FEzdqABN1b3zyO5Ua5OQnogGIW65Iw==", "9d9efa09-91b0-41e9-bc3c-daae1a73c5ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6c63263-689c-4ba3-b7b3-accca5250f28", "AQAAAAIAAYagAAAAEM6lnic5RdUIa9CO08a9vFU0VmS41eG7hvuP9OQ2y9Em/ZkEGLa1y6zNHueyP1yUdw==", "f6845de5-f898-4962-b5c1-f446a9abe2a1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Banks_BankId",
                table: "InvoicePayments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Cashes_CashId",
                table: "InvoicePayments",
                column: "CashId",
                principalTable: "Cashes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Cheques_ChequeId",
                table: "InvoicePayments",
                column: "ChequeId",
                principalTable: "Cheques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_CreditCards_CreditCardId",
                table: "InvoicePayments",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Invoices_InvoiceId",
                table: "InvoicePayments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Areas_AreaId",
                table: "Invoices",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Shippings_ShippingId",
                table: "Invoices",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Warehouses_WarehouseId",
                table: "Invoices",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Banks_BankId",
                table: "PurchasePayments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Cashes_CashId",
                table: "PurchasePayments",
                column: "CashId",
                principalTable: "Cashes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Cheques_ChequeId",
                table: "PurchasePayments",
                column: "ChequeId",
                principalTable: "Cheques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_CreditCards_CreditCardId",
                table: "PurchasePayments",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Purchases_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Products_ProductId",
                table: "PurchaseProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Shippings_ShippingId",
                table: "Purchases",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Warehouses_WarehouseId",
                table: "Purchases",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadyProductItems_Products_ProductId",
                table: "ReadyProductItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadyProductItems_ReadyProducts_ReadyProductId",
                table: "ReadyProductItems",
                column: "ReadyProductId",
                principalTable: "ReadyProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_ReadyProducts_ReadyProductId",
                table: "SaleProducts",
                column: "ReadyProductId",
                principalTable: "ReadyProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Banks_BankId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Cashes_CashId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Cheques_ChequeId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_CreditCards_CreditCardId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePayments_Invoices_InvoiceId",
                table: "InvoicePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Areas_AreaId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Shippings_ShippingId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Warehouses_WarehouseId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Banks_BankId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Cashes_CashId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Cheques_ChequeId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_CreditCards_CreditCardId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Purchases_PurchaseId",
                table: "PurchasePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Products_ProductId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Shippings_ShippingId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Warehouses_WarehouseId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadyProductItems_Products_ProductId",
                table: "ReadyProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadyProductItems_ReadyProducts_ReadyProductId",
                table: "ReadyProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_ReadyProducts_ReadyProductId",
                table: "SaleProducts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f92adc7-358a-42df-8317-411950d5b035", "AQAAAAIAAYagAAAAEHJO/KtMAXmJhzcal2f2RyeUX/J0EZByF5HO3lp/wS/ibYRdZu/SXDGYawVMGehLXw==", "3be4bd50-c2a7-46e8-8256-e49d59b3fb86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0ba2225-cf2f-4a20-8429-bf81a242cd88", "AQAAAAIAAYagAAAAEDSSZuVfPKYH+L9B9xt58ffXEbgIA9TO0E+ysKxXvu44c5NRNZWVKqV5z8YUrHjeUw==", "af1351aa-4c9f-4b09-9fd7-c30a4720c253" });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Banks_BankId",
                table: "InvoicePayments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Cashes_CashId",
                table: "InvoicePayments",
                column: "CashId",
                principalTable: "Cashes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Cheques_ChequeId",
                table: "InvoicePayments",
                column: "ChequeId",
                principalTable: "Cheques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_CreditCards_CreditCardId",
                table: "InvoicePayments",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePayments_Invoices_InvoiceId",
                table: "InvoicePayments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Areas_AreaId",
                table: "Invoices",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Shippings_ShippingId",
                table: "Invoices",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Warehouses_WarehouseId",
                table: "Invoices",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Banks_BankId",
                table: "PurchasePayments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Cashes_CashId",
                table: "PurchasePayments",
                column: "CashId",
                principalTable: "Cashes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Cheques_ChequeId",
                table: "PurchasePayments",
                column: "ChequeId",
                principalTable: "Cheques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_CreditCards_CreditCardId",
                table: "PurchasePayments",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Purchases_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Products_ProductId",
                table: "PurchaseProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Shippings_ShippingId",
                table: "Purchases",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Suppliers_SupplierId",
                table: "Purchases",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Warehouses_WarehouseId",
                table: "Purchases",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadyProductItems_Products_ProductId",
                table: "ReadyProductItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadyProductItems_ReadyProducts_ReadyProductId",
                table: "ReadyProductItems",
                column: "ReadyProductId",
                principalTable: "ReadyProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Products_ProductId",
                table: "SaleProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_ReadyProducts_ReadyProductId",
                table: "SaleProducts",
                column: "ReadyProductId",
                principalTable: "ReadyProducts",
                principalColumn: "Id");
        }
    }
}

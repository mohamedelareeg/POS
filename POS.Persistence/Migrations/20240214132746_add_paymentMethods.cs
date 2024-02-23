using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_paymentMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Purchases",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "PurchasePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CashId",
                table: "PurchasePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChequeId",
                table: "PurchasePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "PurchasePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "InvoicePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CashId",
                table: "InvoicePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChequeId",
                table: "InvoicePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "InvoicePayments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BankName = table.Column<string>(type: "TEXT", nullable: true),
                    PersonName = table.Column<string>(type: "TEXT", nullable: true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cashes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CashName = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankName = table.Column<string>(type: "TEXT", nullable: true),
                    PersonName = table.Column<string>(type: "TEXT", nullable: true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankName = table.Column<string>(type: "TEXT", nullable: true),
                    PersonName = table.Column<string>(type: "TEXT", nullable: true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26086577-4d33-467e-83f3-07b8f9a4ccb1", "AQAAAAIAAYagAAAAEOPuL+hZQqdJxv50TxDV+xfdQR8+QVekS2WGxW900weDs+17IJ+VmHX7ddBl3ofrYw==", "ce61f928-56fb-419f-9d80-eac65f8a7f6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "812a93cf-d7b1-4ba2-804f-cacfaaa1ffc3", "AQAAAAIAAYagAAAAEA7J7rMUv+v7AhR8bucL6LBuSwseCMGnB8YUJ0k2jNt6qyS318Icb8sJnKdKswejAw==", "8d791f67-81ef-43da-addf-d64f7b3743ff" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_BankId",
                table: "PurchasePayments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_CashId",
                table: "PurchasePayments",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_ChequeId",
                table: "PurchasePayments",
                column: "ChequeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_CreditCardId",
                table: "PurchasePayments",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_BankId",
                table: "InvoicePayments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_CashId",
                table: "InvoicePayments",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_ChequeId",
                table: "InvoicePayments",
                column: "ChequeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_CreditCardId",
                table: "InvoicePayments",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expenses",
                column: "EmployeeId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Cashes");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_BankId",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_CashId",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_ChequeId",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_CreditCardId",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_InvoicePayments_BankId",
                table: "InvoicePayments");

            migrationBuilder.DropIndex(
                name: "IX_InvoicePayments_CashId",
                table: "InvoicePayments");

            migrationBuilder.DropIndex(
                name: "IX_InvoicePayments_ChequeId",
                table: "InvoicePayments");

            migrationBuilder.DropIndex(
                name: "IX_InvoicePayments_CreditCardId",
                table: "InvoicePayments");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "CashId",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "ChequeId",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "InvoicePayments");

            migrationBuilder.DropColumn(
                name: "CashId",
                table: "InvoicePayments");

            migrationBuilder.DropColumn(
                name: "ChequeId",
                table: "InvoicePayments");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "InvoicePayments");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Purchases",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Invoices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc1b7db1-08e1-45d7-8975-2b3d64d9f352", "AQAAAAIAAYagAAAAEIHu0wM5Gsh8iIYoqDZxHIqVcS+7OzyGLti4LUi0TLzRqJqxjcbIXC6tM12ymC1/Yw==", "3d3aac9e-5840-4991-9c07-52aea5c03252" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a89c7906-89f7-4398-977d-3b9fa1a1794c", "AQAAAAIAAYagAAAAEC4e7Uw00CCNOHc+c/MNzSnXDQ9zIjpM+thDPMR1PSUHl1Q1r/9jQkPlXhIWVE2szw==", "1896b7b1-6707-4e25-998e-58e30266d59d" });
        }
    }
}

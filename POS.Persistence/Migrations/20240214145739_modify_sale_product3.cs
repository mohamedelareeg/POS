using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sale_product3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
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
                values: new object[] { "7f92adc7-358a-42df-8317-411950d5b035", "AQAAAAIAAYagAAAAEHJO/KtMAXmJhzcal2f2RyeUX/J0EZByF5HO3lp/wS/ibYRdZu/SXDGYawVMGehLXw==", "3be4bd50-c2a7-46e8-8256-e49d59b3fb86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0ba2225-cf2f-4a20-8429-bf81a242cd88", "AQAAAAIAAYagAAAAEDSSZuVfPKYH+L9B9xt58ffXEbgIA9TO0E+ysKxXvu44c5NRNZWVKqV5z8YUrHjeUw==", "af1351aa-4c9f-4b09-9fd7-c30a4720c253" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
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
                values: new object[] { "ca371ddf-26d9-48e5-92ec-dc16e2e3344c", "AQAAAAIAAYagAAAAEGyzbc8S2/mM5nzfC6PHw6b9+jzaBcHcRDMy0tYFujplo6wd5TOlAZy+Y9LrW9IOMw==", "46d42af8-cf89-455c-b1ff-edc2cc7bebe1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4f560c8-2869-4fed-944e-2ca665be5768", "AQAAAAIAAYagAAAAEK/0ZWp8DajTDGNh0Wo8oOzhzxUn62tp8CNSqZeIvYdBAq/5jw0gyd4Mc72ZLlDDKw==", "acfc827f-69ca-4177-aeb6-1679621a6cc5" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Invoices_InvoiceId",
                table: "SaleProducts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sell_purchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SaleProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PurchaseProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f20eaaf4-2ef0-4f47-a3cf-0c150826c6d8", "AQAAAAIAAYagAAAAEPubqEm9VTgj+9J5m/IyLkd7+TsxJz2Vrr5juJ7aUDmKDgTnqJNkSMkV4YljXL1QBQ==", "0b3f1fba-b2ba-47a8-a780-1425a6524f58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02b27e69-7a0b-470f-afce-c69303e91b8f", "AQAAAAIAAYagAAAAECfhSRwgekQs/ypUAaOqg2oZtzKN2wo/JS/ODrQPsox4QadFo1ADxKfIfLoDVwxTjg==", "d33e379e-8fd6-4536-bb30-2c29a2c85f12" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "PurchaseProducts");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "292e3cba-a5bf-4f8c-9d9e-2edea0da42a9", "AQAAAAIAAYagAAAAENh9hkt+dxbrHJ3TkssGCK82Bj8WohR4imynwFHCE4mlT/lUrqPHE2+tVWK1g7iQgA==", "3e34fb03-7884-475a-913c-1cc59685fadc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6add4328-30a8-4a2e-bc92-90a00462c611", "AQAAAAIAAYagAAAAEFwqUSoPfrytsArw1TLfODEJyy2lO3k5MHGShbs8JJ9N1Quu1tzavFnQcb9HY0Khrw==", "1bc99778-9cf8-4ccf-a4b8-bfb97195dfbd" });
        }
    }
}

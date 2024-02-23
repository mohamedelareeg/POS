using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_paymentdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Purchases",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Invoices");

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
    }
}

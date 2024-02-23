using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_product_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PreviousBalance",
                table: "Suppliers",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinSalePrice",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinStock",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProfitMargin",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PreviousBalance",
                table: "Customers",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c2cad09-e5bb-437a-81f8-d0b2f30571a4", "AQAAAAIAAYagAAAAEO0rt4VxIJJtuQZ45b+mWyQqk5t8EoYVk7o6NlcLGrTu2mT0CK1y/RQ8TFyDC9vXGQ==", "a4cfc8e2-22a3-4c35-b5cd-7caa601b5079" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebe9af90-3044-4649-887a-f9c5a56c72b8", "AQAAAAIAAYagAAAAEHBuHaTTF463yAgvlG2tj28p1FfE8GrtnzyXSw4iammJtmtGa5O7LFYh4jvOjrWagg==", "7ed09b72-f63f-433d-9e5c-3b7cd611bafe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousBalance",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "MinSalePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProfitMargin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PreviousBalance",
                table: "Customers");

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
    }
}

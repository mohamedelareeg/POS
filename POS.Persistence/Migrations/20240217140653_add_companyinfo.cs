using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_companyinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CommercialRegister = table.Column<string>(type: "TEXT", nullable: true),
                    TaxCard = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4091f6b5-a641-4cc4-8ea2-a9711efa221d", "AQAAAAIAAYagAAAAEEl8zFIrYpZl9MQXuATuK0/4Q0cgpKR01ScrEtjowrBCZNkKZr9XEypqTs49ec5Pgw==", "132dd80a-8728-40e7-a7f9-fb65a9d833a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65a88c92-1b46-4eb7-8807-58f4e728766a", "AQAAAAIAAYagAAAAEAVAtfhSP/TRFpjNQZSEBruQolDZUtAYgQwxhbWOtK4DoLtKrJytL0i3ON/g7W96ZA==", "cbf69546-85d7-43f8-a7da-d50cc7762139" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfo");

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
    }
}

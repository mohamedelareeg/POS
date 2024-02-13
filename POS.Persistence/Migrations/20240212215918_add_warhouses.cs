using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_warhouses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "889b6403-2835-4d45-809f-1b9f68cfc10e", "AQAAAAIAAYagAAAAENYtiZsPAiPj3AlCydOyARyrtu+zslvVtm7qycgsnNqQF4+o3NS5RtJoT1FOgGk2nA==", "4f2958cc-e099-4066-9a2a-f3d5fe88bb4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15e558be-2d23-4bcc-8285-75351123ca8e", "AQAAAAIAAYagAAAAENy5JtmTkuV2K28ecGWE/e5w96mOi38+9z/ekueZxXe9o7Y38r+ERZJXLLoCZkOljA==", "06542d16-740b-4c93-9915-d3c77503d4c2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed46148f-2734-42df-9278-e75f55353bca", "AQAAAAIAAYagAAAAEMaaU8JXqgizSRjFFlW5g8/dN9D7mukTZS3s8xhS8D2K4sczejZbftchZAr00cUIFQ==", "b9523374-fd51-4aa4-8af5-e7b45151da2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6f4637e-6f80-412b-8438-4ecf4bedb39a", "AQAAAAIAAYagAAAAEPYcYx+pqK8tafFIB/4z8wTKFOzJyEl5Czade2ovRmy3dNOWonm1Iyj1RY/XsdRhlg==", "76eda103-e08a-4b54-b94d-ae678605f8f6" });
        }
    }
}

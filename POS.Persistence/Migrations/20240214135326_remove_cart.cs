using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class remove_cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "SaleProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Earned",
                table: "SaleProducts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "PurchaseProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5c4e014-99f4-4440-82ee-fc657a0114a4", "AQAAAAIAAYagAAAAEESBKUAXy2wq722O9LB3C/7KuTSn1bV35P8P0DE5NnlifkWiqUwFM/UyI1r0PYEOew==", "9d205876-4994-46e5-94ea-b82dd1ad2f32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bfc4a43-67b2-4d28-bc0f-8fa7c923e437", "AQAAAAIAAYagAAAAEGXQKCfEZttIS8mgfTUoqjFFkpfpbdY5Ep47PJ51ndeNaJLvl7cs5kjKrzN+Y0+Ltw==", "b5349955-b232-48b0-ae79-2f7fb704e3fb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "Earned",
                table: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "PurchaseProducts");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Barcode = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    Datex = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    Earned = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
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
        }
    }
}

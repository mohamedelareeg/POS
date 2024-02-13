using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_warhouse_nullable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Warehouses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51cd4980-cdff-445c-a5b0-e0c5dc0d96eb", "AQAAAAIAAYagAAAAEDM1KdyVxeX5RxOQBYhtNCzGXPUdac9J5sZ3WrL6C3FIHXhPb6mkAdyt9Lr+4jFq0g==", "909d8a17-15e2-48fb-b8ef-6551273d51fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09a031ff-5bf1-4728-ae16-de28c35203ab", "AQAAAAIAAYagAAAAELc3ifz5gi3Y7qBgWrDGEdoCtUW8NSYg4KTrkQQQ9qQTje1W8Uv4z/HPTNsfG9HZKQ==", "906cddfb-d931-4819-8233-590a7f4fffb1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17247da9-bd11-4268-996f-a4af3776ce9f", "AQAAAAIAAYagAAAAEJCy8m+xWVQ7p7YmUD9cVzSpw43wWSMldgeYaHgEW28mvF2KHt+sqekt+9ScMICWnQ==", "38489f4f-a5f8-4c0d-a1c8-1e7596ff967a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8898ee69-5058-4558-8f39-6e5f13b7300f", "AQAAAAIAAYagAAAAEGtUlYd5NwOkbO2zDkk2mCAhrxG2LQooHhXDtnnsihHkWWrN44Ef529SrhPXnMsnjw==", "79a4ad1c-ca26-419e-9b4e-1566e5f39355" });
        }
    }
}

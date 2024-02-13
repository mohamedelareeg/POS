using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_warhouse_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "031ea074-b4dc-4791-ac47-e391c4e4c38c", "AQAAAAIAAYagAAAAEE0D28Co4eL0SiBnntQwyRWOdqM90oDQBsllgcCDJRDgLQdyTNEBA9Mvj4/6TT5Nog==", "03305f2a-2201-40b8-a02e-81835f2baff5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0be21834-3299-4155-a603-c3b92b53f5c3", "AQAAAAIAAYagAAAAEAOc1zi0p3UCVe8T5XOjFVSOYUYnYT8mS+EZR6KtG2b5DuUJBe83o3282lP46O/KGg==", "d4833d6a-f616-4f76-b468-6201ada5af96" });
        }
    }
}

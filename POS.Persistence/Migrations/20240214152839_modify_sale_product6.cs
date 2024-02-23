using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sale_product6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d5114f-ade0-4bba-a093-29c6e7414b1a", "AQAAAAIAAYagAAAAEChcanUwlbiXjReb1dHfD23YkqcXTglxyA+4Ek5o1ES8Ro4+rCeMNmM4FWeFWJKn+A==", "c682d6ba-6520-43ad-8e10-a967eafc37de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56883176-23a4-4cb3-8a83-215a1e222a67", "AQAAAAIAAYagAAAAEKcg4dMaxSHTA9Gz7rlmj2QX2IwNzvWrXo7tBCfHA7+MgR9/AX/X7JZ58Uxixm2j4w==", "e051086c-0c67-4c56-afa9-16a7a0739e13" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076521d5-d31e-4f94-8e31-69b7bb76fb96", "AQAAAAIAAYagAAAAEEofhZ5DJV6JaYmh2UUqntDz6M/mnIkgWeg5FEzdqABN1b3zyO5Ua5OQnogGIW65Iw==", "9d9efa09-91b0-41e9-bc3c-daae1a73c5ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6c63263-689c-4ba3-b7b3-accca5250f28", "AQAAAAIAAYagAAAAEM6lnic5RdUIa9CO08a9vFU0VmS41eG7hvuP9OQ2y9Em/ZkEGLa1y6zNHueyP1yUdw==", "f6845de5-f898-4962-b5c1-f446a9abe2a1" });
        }
    }
}

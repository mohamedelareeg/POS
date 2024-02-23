using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_sale_product7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c74d9878-fc29-4b7f-a599-f29f58d24571", "AQAAAAIAAYagAAAAEDtXN2F+sSZ8xAtnCyrt+Me+XcvCMKPyCYxpP/se+EjrQXTIBJ4Dj5VLA1+TZlWUAQ==", "f83542fe-aa33-47e1-81dd-d76904a1aafb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ead13a31-56bd-487c-9deb-0f7f3d53bd79", "AQAAAAIAAYagAAAAEOd8zLA7hydMIMlkYgx5g0CoWC6p42J+oNa2GcdHVWSF8sPB5U4hjLY5iN9rGWKsbQ==", "be86d7fe-57d4-4fc9-be45-9db73a22169b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

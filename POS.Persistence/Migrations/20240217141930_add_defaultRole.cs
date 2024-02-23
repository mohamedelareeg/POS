using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_defaultRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultRole",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DefaultRole", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8068e01-5aed-496e-a647-6ffc954e5da1", null, "AQAAAAIAAYagAAAAEHpGAm+jySRO4gGxlSHCkO4cmM1Oen4jcrVbySvIW4IzNx9pRfpIHTBu3uVtXEelGg==", "948d8c12-b7c8-4478-8a47-93aa79487d69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DefaultRole", "PasswordHash", "SecurityStamp" },
                values: new object[] { "437d09e5-3ada-4251-bd5a-6ac528dde2d1", null, "AQAAAAIAAYagAAAAEB+ODJywihGvlCvERpGMuf5Tp2vbyZZfaRErZ+SmY3RF/FfnZNL0ReA5Q3qqBgNjWw==", "ce0b56ed-4558-4b4e-a0d2-eb03071928d6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultRole",
                table: "AspNetUsers");

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
    }
}

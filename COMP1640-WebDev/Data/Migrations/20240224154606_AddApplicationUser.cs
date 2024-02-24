using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640_WebDev.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61e4e3f9-fc4f-4d77-85bf-3af3ba62a4c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69721c49-d922-4cfb-92f9-2cd2ecf51e21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9649201b-0c43-475c-b010-dc3b9511f4c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc533adb-1f37-4a0b-8de1-0c08203cb257");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef5eee91-9b62-4807-8424-1bf670e70d37");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03f4e885-2e5e-4937-9227-a261f458e05c", "5", "Guest", "Guest" },
                    { "40cd385a-e072-46eb-8277-d6a0c0280c99", "3", "Marketing Coordinator", "Marketing Coordinator" },
                    { "47c2db1d-b7df-4a99-820f-9dbdcad849cc", "2", "Marketing Manager", "Marketing Manager" },
                    { "967e0328-7245-4df9-be2a-8fcf23712040", "1", "Admin", "Admin" },
                    { "be1d7430-3158-4cb1-8486-cda4f007a06d", "4", "Student", "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f4e885-2e5e-4937-9227-a261f458e05c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40cd385a-e072-46eb-8277-d6a0c0280c99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47c2db1d-b7df-4a99-820f-9dbdcad849cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e0328-7245-4df9-be2a-8fcf23712040");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be1d7430-3158-4cb1-8486-cda4f007a06d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61e4e3f9-fc4f-4d77-85bf-3af3ba62a4c4", "5", "Guest", "Guest" },
                    { "69721c49-d922-4cfb-92f9-2cd2ecf51e21", "2", "Marketing Manager", "Marketing Manager" },
                    { "9649201b-0c43-475c-b010-dc3b9511f4c7", "4", "Student", "Student" },
                    { "dc533adb-1f37-4a0b-8de1-0c08203cb257", "3", "Marketing Coordinator", "Marketing Coordinator" },
                    { "ef5eee91-9b62-4807-8424-1bf670e70d37", "1", "Admin", "Admin" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class Updatetableuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fa46923-3f30-4687-a39c-a6f8bccdb671");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75456cae-c8a2-4fbc-be03-254f9b0e1576");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fbfbdf6-29b9-4a72-a543-e8fd9a067ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2029172-c83b-4600-bd67-98699bd38c31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec9c0b40-f9dd-4a16-8c52-8b998fed7bae");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "089967f7-aeef-4edb-8fff-b2945b7f67ee", "1", "Admin", "Admin" },
                    { "2857e31b-220c-4c57-a1d1-74b2fb1c2092", "3", "Marketing Coordinator", "Marketing Coordinator" },
                    { "3b1b21f3-d0d0-4fa3-96fc-1f953261dab4", "2", "Marketing Manager", "Marketing Manager" },
                    { "8ce56b47-240d-461a-a7fd-158f8c291c93", "5", "Guest", "Guest" },
                    { "a5858339-3afe-4de7-8752-138f4f3f17ce", "4", "Student", "Student" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "089967f7-aeef-4edb-8fff-b2945b7f67ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2857e31b-220c-4c57-a1d1-74b2fb1c2092");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b1b21f3-d0d0-4fa3-96fc-1f953261dab4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ce56b47-240d-461a-a7fd-158f8c291c93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5858339-3afe-4de7-8752-138f4f3f17ce");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fa46923-3f30-4687-a39c-a6f8bccdb671", "4", "Student", "Student" },
                    { "75456cae-c8a2-4fbc-be03-254f9b0e1576", "5", "Guest", "Guest" },
                    { "9fbfbdf6-29b9-4a72-a543-e8fd9a067ac9", "3", "Marketing Coordinator", "Marketing Coordinator" },
                    { "d2029172-c83b-4600-bd67-98699bd38c31", "2", "Marketing Manager", "Marketing Manager" },
                    { "ec9c0b40-f9dd-4a16-8c52-8b998fed7bae", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

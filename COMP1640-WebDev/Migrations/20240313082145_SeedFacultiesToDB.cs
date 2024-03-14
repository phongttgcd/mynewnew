using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class SeedFacultiesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "FacultyName" },
                values: new object[,]
                {
                    { "AGR", "Faculty of Agriculture" },
                    { "ART", "Faculty of Arts and Humanities" },
                    { "BUS", "Faculty of Business Administration" },
                    { "EDU", "Faculty of Education" },
                    { "ENG", "Faculty of Engineering" },
                    { "IT", "Faculty of Information Technology" },
                    { "LAW", "Faculty of Law" },
                    { "MED", "Faculty of Medicine" },
                    { "SCI", "Faculty of Science" },
                    { "SOC", "Faculty of Social Sciences" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "AGR");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "ART");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "BUS");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "EDU");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "ENG");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "IT");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "LAW");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "MED");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "SCI");

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "SOC");
        }
    }
}

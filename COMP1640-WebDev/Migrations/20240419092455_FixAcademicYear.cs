using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class FixAcademicYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicYears_Faculties_FacultyId",
                table: "AcademicYears");

            migrationBuilder.DropIndex(
                name: "IX_AcademicYears_FacultyId",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "AcademicYears");

            migrationBuilder.AddColumn<string>(
                name: "FacultyId",
                table: "Faculties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "AGR",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "ART",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "BUS",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "EDU",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "ENG",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "IT",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "LAW",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "MED",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "SCI",
                column: "FacultyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: "SOC",
                column: "FacultyId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_FacultyId",
                table: "Faculties",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Faculties_FacultyId",
                table: "Faculties",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Faculties_FacultyId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_FacultyId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Faculties");

            migrationBuilder.AddColumn<string>(
                name: "FacultyId",
                table: "AcademicYears",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_FacultyId",
                table: "AcademicYears",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicYears_Faculties_FacultyId",
                table: "AcademicYears",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

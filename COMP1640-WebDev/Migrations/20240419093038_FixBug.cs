using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class FixBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Faculties_FacultyId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_AcademicYears_AcademicYearId",
                table: "Magazines");

            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_Faculties_FacultyId",
                table: "Magazines");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_FacultyId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Faculties");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Magazines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcademicYearId",
                table: "Magazines",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_AcademicYears_AcademicYearId",
                table: "Magazines",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_Faculties_FacultyId",
                table: "Magazines",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_AcademicYears_AcademicYearId",
                table: "Magazines");

            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_Faculties_FacultyId",
                table: "Magazines");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Magazines",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicYearId",
                table: "Magazines",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_AcademicYears_AcademicYearId",
                table: "Magazines",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_Faculties_FacultyId",
                table: "Magazines",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }
    }
}

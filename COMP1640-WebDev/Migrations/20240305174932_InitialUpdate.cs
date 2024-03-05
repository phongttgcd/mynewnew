using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicYear_Faculty_FacultyId",
                table: "AcademicYear");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculty_FacultyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_AcademicYear_AcademicYearId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_AspNetUsers_UserId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Contribution_ContributionId",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribution",
                table: "Contribution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicYear",
                table: "AcademicYear");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1073ad4f-b739-4b07-b4fd-95faf602478b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e536ab8-8f59-4517-9783-2f709aebbfd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7429def9-d625-40c9-af95-56aa8d3b0f72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcdbd22f-a700-425e-ac85-828c4cfb1a33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4246a0d-00f6-4b7d-bed8-0625498a2cc9");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "Faculty",
                newName: "Faculties");

            migrationBuilder.RenameTable(
                name: "Contribution",
                newName: "Contributions");

            migrationBuilder.RenameTable(
                name: "AcademicYear",
                newName: "AcademicYears");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_ContributionId",
                table: "Notifications",
                newName: "IX_Notifications_ContributionId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_UserId",
                table: "Contributions",
                newName: "IX_Contributions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_AcademicYearId",
                table: "Contributions",
                newName: "IX_Contributions_AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicYear_FacultyId",
                table: "AcademicYears",
                newName: "IX_AcademicYears_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contributions",
                table: "Contributions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicYears",
                table: "AcademicYears",
                column: "Id");

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
                name: "FK_AcademicYears_Faculties_FacultyId",
                table: "AcademicYears",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_AcademicYears_AcademicYearId",
                table: "Contributions",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_AspNetUsers_UserId",
                table: "Contributions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Contributions_ContributionId",
                table: "Notifications",
                column: "ContributionId",
                principalTable: "Contributions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicYears_Faculties_FacultyId",
                table: "AcademicYears");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_AcademicYears_AcademicYearId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_AspNetUsers_UserId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Contributions_ContributionId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contributions",
                table: "Contributions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicYears",
                table: "AcademicYears");

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

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "Faculties",
                newName: "Faculty");

            migrationBuilder.RenameTable(
                name: "Contributions",
                newName: "Contribution");

            migrationBuilder.RenameTable(
                name: "AcademicYears",
                newName: "AcademicYear");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notification",
                newName: "IX_Notification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_ContributionId",
                table: "Notification",
                newName: "IX_Notification_ContributionId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_UserId",
                table: "Contribution",
                newName: "IX_Contribution_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_AcademicYearId",
                table: "Contribution",
                newName: "IX_Contribution_AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicYears_FacultyId",
                table: "AcademicYear",
                newName: "IX_AcademicYear_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribution",
                table: "Contribution",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicYear",
                table: "AcademicYear",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1073ad4f-b739-4b07-b4fd-95faf602478b", "2", "Marketing Manager", "Marketing Manager" },
                    { "2e536ab8-8f59-4517-9783-2f709aebbfd7", "3", "Marketing Coordinator", "Marketing Coordinator" },
                    { "7429def9-d625-40c9-af95-56aa8d3b0f72", "5", "Guest", "Guest" },
                    { "dcdbd22f-a700-425e-ac85-828c4cfb1a33", "4", "Student", "Student" },
                    { "e4246a0d-00f6-4b7d-bed8-0625498a2cc9", "1", "Admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicYear_Faculty_FacultyId",
                table: "AcademicYear",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculty_FacultyID",
                table: "AspNetUsers",
                column: "FacultyID",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_AcademicYear_AcademicYearId",
                table: "Contribution",
                column: "AcademicYearId",
                principalTable: "AcademicYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_AspNetUsers_UserId",
                table: "Contribution",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Contribution_ContributionId",
                table: "Notification",
                column: "ContributionId",
                principalTable: "Contribution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

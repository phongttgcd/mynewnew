using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class Seeddataadminaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "089967f7-aeef-4edb-8fff-b2945b7f67e2", "2", "Marketing Manager", "Marketing Manager" },
                    { "089967f7-aeef-4edb-8fff-b2945b7f67e3", "3", "Marketing Coordinator", "Marketing Coordinator" },
                    { "089967f7-aeef-4edb-8fff-b2945b7f67e4", "4", "Student", "Student" },
                    { "089967f7-aeef-4edb-8fff-b2945b7f67e5", "5", "Guest", "Guest" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedTime", "Email", "EmailConfirmed", "FacultyID", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "089967f7-aeef-4edb-8fff-b2945b7f67e1", 0, "d719e974-32f6-4ff1-b45b-5e1f5ca82808", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, null, true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKP/gJ6XGMLQpnKKGQH7IsGMKoqwwAyh5MGKWcnLP3OBjP/DRkS4PFY1BfiRbVjfWg==", null, false, "VAXURNACT25EQBDVHYPTL7OHXP6OHZXM", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "089967f7-aeef-4edb-8fff-b2945b7f67ee", "089967f7-aeef-4edb-8fff-b2945b7f67e1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "089967f7-aeef-4edb-8fff-b2945b7f67e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "089967f7-aeef-4edb-8fff-b2945b7f67e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "089967f7-aeef-4edb-8fff-b2945b7f67e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "089967f7-aeef-4edb-8fff-b2945b7f67e5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "089967f7-aeef-4edb-8fff-b2945b7f67ee", "089967f7-aeef-4edb-8fff-b2945b7f67e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "089967f7-aeef-4edb-8fff-b2945b7f67e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2857e31b-220c-4c57-a1d1-74b2fb1c2092", "3", "Marketing Coordinator", "Marketing Coordinator" },
                    { "3b1b21f3-d0d0-4fa3-96fc-1f953261dab4", "2", "Marketing Manager", "Marketing Manager" },
                    { "8ce56b47-240d-461a-a7fd-158f8c291c93", "5", "Guest", "Guest" },
                    { "a5858339-3afe-4de7-8752-138f4f3f17ce", "4", "Student", "Student" }
                });
        }
    }
}

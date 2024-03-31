using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class CreateMagazinesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FacultyID",
                table: "AspNetUsers",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_FacultyID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_FacultyId");

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magazines_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Magazines_FacultyId",
                table: "Magazines",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Magazines");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "AspNetUsers",
                newName: "FacultyID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_FacultyId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_FacultyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyID",
                table: "AspNetUsers",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "Id");
        }
    }
}

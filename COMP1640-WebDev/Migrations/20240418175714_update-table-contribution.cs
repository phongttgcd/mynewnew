using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1640_WebDev.Migrations
{
    /// <inheritdoc />
    public partial class updatetablecontribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contributions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contributions");
        }
    }
}

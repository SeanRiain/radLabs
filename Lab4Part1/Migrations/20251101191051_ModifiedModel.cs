using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rad301_2025_Week2_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "Todos",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Todos",
                newName: "IsComplete");
        }
    }
}

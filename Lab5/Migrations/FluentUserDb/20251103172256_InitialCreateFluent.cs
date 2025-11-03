using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5.Migrations.FluentUserDb
{
    /// <inheritdoc />
    public partial class InitialCreateFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_FirstName = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    user_LastName = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    title = table.Column<int>(type: "INTEGER", nullable: false),
                    Biography = table.Column<string>(type: "TEXT", nullable: false),
                    age_of_user = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FluentUserExtension",
                columns: table => new
                {
                    FluentUserID = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<int>(type: "INTEGER", nullable: false),
                    Biography = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentUserExtension", x => x.FluentUserID);
                    table.ForeignKey(
                        name: "FK_FluentUserExtension_FluentUsers_FluentUserID",
                        column: x => x.FluentUserID,
                        principalTable: "FluentUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentUserExtension");

            migrationBuilder.DropTable(
                name: "FluentUsers");
        }
    }
}

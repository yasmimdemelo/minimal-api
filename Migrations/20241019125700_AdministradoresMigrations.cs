using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api.Migrations
{
    /// <inheritdoc />
    public partial class AdministradoresMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adiministradores",
                table: "Adiministradores");

            migrationBuilder.RenameTable(
                name: "Adiministradores",
                newName: "Administradores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores");

            migrationBuilder.RenameTable(
                name: "Administradores",
                newName: "Adiministradores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adiministradores",
                table: "Adiministradores",
                column: "Id");
        }
    }
}

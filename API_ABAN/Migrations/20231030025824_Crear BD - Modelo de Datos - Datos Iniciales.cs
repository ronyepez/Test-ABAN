using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_ABAN.Migrations
{
    /// <inheritdoc />
    public partial class CrearBDModelodeDatosDatosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "Date", nullable: true),
                    CUIT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    DeletedAt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    DireccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeletedAt = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.DireccionId);
                    table.ForeignKey(
                        name: "FK_Direcciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "CUIT", "Celular", "DeletedAt", "Email", "FechaNacimiento", "Nombres" },
                values: new object[,]
                {
                    { 1, "Pérez", "252032546", 1125631478, false, "pperez@gmail.com", new DateTime(2000, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro" },
                    { 2, "Santana", "202054564", 1165231590, false, "msantana@gmail.com", new DateTime(1995, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "María" },
                    { 3, "Contreras", "252005569", 1161971590, false, "ccontreras@gmail.com", new DateTime(1999, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carmen" }
                });

            migrationBuilder.InsertData(
                table: "Direcciones",
                columns: new[] { "DireccionId", "Calle", "Ciudad", "ClienteId", "DeletedAt", "Numero", "Pais", "Provincia" },
                values: new object[,]
                {
                    { 1, "Calle 2", "Ciudad B", 1, false, 123, "Argentina", "Provincia A" },
                    { 2, "Calle 3", "Ciudad A", 3, false, 321, "Argentina", "Provincia B" },
                    { 3, "Calle 1", "Ciudad C", 2, false, 456, "Argentina", "Provincia C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ClienteId",
                table: "Direcciones",
                column: "ClienteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

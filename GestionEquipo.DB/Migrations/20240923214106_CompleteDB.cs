using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEquipo.DB.Migrations
{
    /// <inheritdoc />
    public partial class CompleteDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrenamientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenamientos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Posicion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rival = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AsistEntrenamientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asistio = table.Column<bool>(type: "bit", nullable: false),
                    JugadorID = table.Column<int>(type: "int", nullable: false),
                    EntrenamientoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistEntrenamientos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AsistEntrenamientos_Entrenamientos_EntrenamientoID",
                        column: x => x.EntrenamientoID,
                        principalTable: "Entrenamientos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsistEntrenamientos_Jugadores_JugadorID",
                        column: x => x.JugadorID,
                        principalTable: "Jugadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstPartidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goles = table.Column<int>(type: "int", nullable: false),
                    Asistencias = table.Column<int>(type: "int", nullable: false),
                    MinutosJugados = table.Column<int>(type: "int", nullable: false),
                    JugadorID = table.Column<int>(type: "int", nullable: false),
                    PartidoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstPartidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EstPartidos_Jugadores_JugadorID",
                        column: x => x.JugadorID,
                        principalTable: "Jugadores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstPartidos_Partidos_PartidoID",
                        column: x => x.PartidoID,
                        principalTable: "Partidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "AsistEntrenamiento_UQ",
                table: "AsistEntrenamientos",
                columns: new[] { "JugadorID", "EntrenamientoID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AsistEntrenamientos_EntrenamientoID",
                table: "AsistEntrenamientos",
                column: "EntrenamientoID");

            migrationBuilder.CreateIndex(
                name: "EstPartido_UQ",
                table: "EstPartidos",
                columns: new[] { "JugadorID", "PartidoID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstPartidos_PartidoID",
                table: "EstPartidos",
                column: "PartidoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistEntrenamientos");

            migrationBuilder.DropTable(
                name: "EstPartidos");

            migrationBuilder.DropTable(
                name: "Entrenamientos");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}

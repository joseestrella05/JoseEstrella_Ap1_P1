using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoseEstrella_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<int>(type: "INTEGER", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudoresId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudoresId);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalles",
                columns: table => new
                {
                    DetallId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCobrado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalles", x => x.DetallId);
                    table.ForeignKey(
                        name: "FK_CobrosDetalles_Cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concepto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Balance = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<int>(type: "INTEGER", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudoresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudoresId", "Nombres" },
                values: new object[] { 1, "Reyphill Nuñez" });

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalles_CobroId",
                table: "CobrosDetalles",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_DeudorId",
                table: "Prestamos",
                column: "DeudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrosDetalles");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Deudores");
        }
    }
}

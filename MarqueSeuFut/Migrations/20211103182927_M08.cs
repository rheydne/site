using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarqueSeuFut.Migrations
{
    public partial class M08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quadra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCasaId = table.Column<int>(type: "int", nullable: false),
                    TimeVisitanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Times_TimeCasaId",
                        column: x => x.TimeCasaId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Times_TimeVisitanteId",
                        column: x => x.TimeVisitanteId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeCasaId",
                table: "Partidas",
                column: "TimeCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeVisitanteId",
                table: "Partidas",
                column: "TimeVisitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");
        }
    }
}

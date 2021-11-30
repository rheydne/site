using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarqueSeuFut.Migrations
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCasaId = table.Column<int>(type: "int", nullable: false),
                    TimeVisitanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Times_TimeCasaId",
                        column: x => x.TimeCasaId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Times_TimeVisitanteId",
                        column: x => x.TimeVisitanteId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_TimeCasaId",
                table: "Agendas",
                column: "TimeCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_TimeVisitanteId",
                table: "Agendas",
                column: "TimeVisitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}

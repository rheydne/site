using Microsoft.EntityFrameworkCore.Migrations;

namespace MarqueSeuFut.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    EstatisticaId = table.Column<int>(type: "int", nullable: false),
                    EscalacaoId = table.Column<int>(type: "int", nullable: false),
                    PartidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Escalacoes_EscalacaoId",
                        column: x => x.EscalacaoId,
                        principalTable: "Escalacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Perfil_Estatisticas_EstatisticaId",
                        column: x => x.EstatisticaId,
                        principalTable: "Estatisticas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Perfil_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Perfil_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_EscalacaoId",
                table: "Perfil",
                column: "EscalacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_EstatisticaId",
                table: "Perfil",
                column: "EstatisticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_PartidaId",
                table: "Perfil",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_TimeId",
                table: "Perfil",
                column: "TimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}

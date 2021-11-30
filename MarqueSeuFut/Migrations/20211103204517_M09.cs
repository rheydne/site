using Microsoft.EntityFrameworkCore.Migrations;

namespace MarqueSeuFut.Migrations
{
    public partial class M09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatisticas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidaId = table.Column<int>(type: "int", nullable: false),
                    GolsF = table.Column<int>(type: "int", nullable: false),
                    GolsS = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatisticas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estatisticas_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estatisticas_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estatisticas_PartidaId",
                table: "Estatisticas",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estatisticas_TimeId",
                table: "Estatisticas",
                column: "TimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estatisticas");
        }
    }
}

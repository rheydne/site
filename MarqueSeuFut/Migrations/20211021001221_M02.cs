using Microsoft.EntityFrameworkCore.Migrations;

namespace MarqueSeuFut.Migrations
{
    public partial class M02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Posicoes_PosicaoId",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores");

            migrationBuilder.CreateTable(
                name: "Escalacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    JogadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escalacoes_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Escalacoes_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escalacoes_JogadorId",
                table: "Escalacoes",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Escalacoes_TimeId",
                table: "Escalacoes",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Posicoes_PosicaoId",
                table: "Jogadores",
                column: "PosicaoId",
                principalTable: "Posicoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Posicoes_PosicaoId",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores");

            migrationBuilder.DropTable(
                name: "Escalacoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Posicoes_PosicaoId",
                table: "Jogadores",
                column: "PosicaoId",
                principalTable: "Posicoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

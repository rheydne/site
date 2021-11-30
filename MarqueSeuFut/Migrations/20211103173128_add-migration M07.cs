using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarqueSeuFut.Migrations
{
    public partial class addmigrationM07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropColumn(
                name: "Líder",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Times");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Líder",
                table: "Times",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Times",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time1Id = table.Column<int>(type: "int", nullable: false),
                    Time2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Times_Time1Id",
                        column: x => x.Time1Id,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Times_Time2Id",
                        column: x => x.Time2Id,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_Time1Id",
                table: "Partidas",
                column: "Time1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_Time2Id",
                table: "Partidas",
                column: "Time2Id");
        }
    }
}

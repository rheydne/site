using Microsoft.EntityFrameworkCore.Migrations;

namespace MarqueSeuFut.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsTItular",
                table: "Escalacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTItular",
                table: "Escalacoes");
        }
    }
}

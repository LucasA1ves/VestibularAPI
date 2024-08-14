using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VestibularAPI.Migrations
{
    public partial class AdicionarDescricaoEVagasDisponiveisEmOferta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Ofertas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VagasDisponiveis",
                table: "Ofertas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Ofertas");

            migrationBuilder.DropColumn(
                name: "VagasDisponiveis",
                table: "Ofertas");
        }
    }
}

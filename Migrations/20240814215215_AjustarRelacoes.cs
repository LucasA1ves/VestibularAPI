using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VestibularAPI.Migrations
{
    public partial class AjustarRelacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfertaId1",
                table: "Inscricoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessoSeletivoId1",
                table: "Inscricoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_OfertaId1",
                table: "Inscricoes",
                column: "OfertaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_ProcessoSeletivoId1",
                table: "Inscricoes",
                column: "ProcessoSeletivoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_Ofertas_OfertaId1",
                table: "Inscricoes",
                column: "OfertaId1",
                principalTable: "Ofertas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_ProcessosSeletivos_ProcessoSeletivoId1",
                table: "Inscricoes",
                column: "ProcessoSeletivoId1",
                principalTable: "ProcessosSeletivos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_Ofertas_OfertaId1",
                table: "Inscricoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_ProcessosSeletivos_ProcessoSeletivoId1",
                table: "Inscricoes");

            migrationBuilder.DropIndex(
                name: "IX_Inscricoes_OfertaId1",
                table: "Inscricoes");

            migrationBuilder.DropIndex(
                name: "IX_Inscricoes_ProcessoSeletivoId1",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "OfertaId1",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "ProcessoSeletivoId1",
                table: "Inscricoes");
        }
    }
}

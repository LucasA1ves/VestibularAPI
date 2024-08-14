using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VestibularAPI.Migrations
{
    public partial class AtualizarRelacionamentos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidatoId1",
                table: "Inscricoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_CandidatoId1",
                table: "Inscricoes",
                column: "CandidatoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_Candidatos_CandidatoId1",
                table: "Inscricoes",
                column: "CandidatoId1",
                principalTable: "Candidatos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_Candidatos_CandidatoId1",
                table: "Inscricoes");

            migrationBuilder.DropIndex(
                name: "IX_Inscricoes_CandidatoId1",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "CandidatoId1",
                table: "Inscricoes");
        }
    }
}

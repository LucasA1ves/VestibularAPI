using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VestibularAPI.Migrations
{
    public partial class UpdateInscricaoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInscricao",
                table: "Inscricoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumInscricao",
                table: "Inscricoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessoSeletivoId",
                table: "Inscricoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_ProcessoSeletivoId",
                table: "Inscricoes",
                column: "ProcessoSeletivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_ProcessosSeletivos_ProcessoSeletivoId",
                table: "Inscricoes",
                column: "ProcessoSeletivoId",
                principalTable: "ProcessosSeletivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_ProcessosSeletivos_ProcessoSeletivoId",
                table: "Inscricoes");

            migrationBuilder.DropIndex(
                name: "IX_Inscricoes_ProcessoSeletivoId",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "DataInscricao",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "NumInscricao",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "ProcessoSeletivoId",
                table: "Inscricoes");
        }
    }
}

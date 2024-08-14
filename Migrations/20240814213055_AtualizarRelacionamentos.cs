using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VestibularAPI.Migrations
{
    public partial class AtualizarRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_ProcessosSeletivos_ProcessoSeletivoId",
                table: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Ofertas_ProcessoSeletivoId",
                table: "Ofertas");

            migrationBuilder.DropColumn(
                name: "ProcessoSeletivoId",
                table: "Ofertas");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Ofertas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidatos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Ofertas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "ProcessoSeletivoId",
                table: "Ofertas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidatos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_ProcessoSeletivoId",
                table: "Ofertas",
                column: "ProcessoSeletivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_ProcessosSeletivos_ProcessoSeletivoId",
                table: "Ofertas",
                column: "ProcessoSeletivoId",
                principalTable: "ProcessosSeletivos",
                principalColumn: "Id");
        }
    }
}

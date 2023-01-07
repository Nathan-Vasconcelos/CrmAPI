using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmApi.Migrations
{
    public partial class Relacionandopareceresecontatoatendimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContatoAtendimentoId",
                table: "Pareceres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pareceres_ContatoAtendimentoId",
                table: "Pareceres",
                column: "ContatoAtendimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pareceres_ContatoAtendimentos_ContatoAtendimentoId",
                table: "Pareceres",
                column: "ContatoAtendimentoId",
                principalTable: "ContatoAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pareceres_ContatoAtendimentos_ContatoAtendimentoId",
                table: "Pareceres");

            migrationBuilder.DropIndex(
                name: "IX_Pareceres_ContatoAtendimentoId",
                table: "Pareceres");

            migrationBuilder.DropColumn(
                name: "ContatoAtendimentoId",
                table: "Pareceres");
        }
    }
}

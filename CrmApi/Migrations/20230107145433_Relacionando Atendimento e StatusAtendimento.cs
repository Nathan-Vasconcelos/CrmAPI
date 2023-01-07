using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmApi.Migrations
{
    public partial class RelacionandoAtendimentoeStatusAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusAtendimentoId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_StatusAtendimentoId",
                table: "Atendimentos",
                column: "StatusAtendimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_StatusAtendimentos_StatusAtendimentoId",
                table: "Atendimentos",
                column: "StatusAtendimentoId",
                principalTable: "StatusAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_StatusAtendimentos_StatusAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_StatusAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "StatusAtendimentoId",
                table: "Atendimentos");
        }
    }
}

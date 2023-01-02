using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmApi.Migrations
{
    public partial class Relacionandoastabelasusuarioecliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ClienteId",
                table: "Atendimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_UsuarioId",
                table: "Atendimentos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Clientes_ClienteId",
                table: "Atendimentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Usuarios_UsuarioId",
                table: "Atendimentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Clientes_ClienteId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Usuarios_UsuarioId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_ClienteId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_UsuarioId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Atendimentos");
        }
    }
}

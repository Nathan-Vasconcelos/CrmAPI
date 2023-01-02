using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace CrmApi.Migrations
{
    public partial class relacionandoAtendimentoeTipoAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoAtendimentoId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoAtendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAtendimentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_TipoAtendimentoId",
                table: "Atendimentos",
                column: "TipoAtendimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_TipoAtendimentos_TipoAtendimentoId",
                table: "Atendimentos",
                column: "TipoAtendimentoId",
                principalTable: "TipoAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_TipoAtendimentos_TipoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.DropTable(
                name: "TipoAtendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_TipoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "TipoAtendimentoId",
                table: "Atendimentos");
        }
    }
}

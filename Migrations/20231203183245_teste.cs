using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eclipseworksteste.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodUsuario",
                table: "HistoricoTarefa");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoTarefa_CodUsuario",
                table: "HistoricoTarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa",
                column: "CodHistorico",
                principalTable: "Tarefa",
                principalColumn: "CodTarefa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodHistorico",
                table: "HistoricoTarefa",
                column: "CodHistorico",
                principalTable: "Usuario",
                principalColumn: "CodUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodHistorico",
                table: "HistoricoTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefa_CodUsuario",
                table: "HistoricoTarefa",
                column: "CodUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa",
                column: "CodHistorico",
                principalTable: "Tarefa",
                principalColumn: "CodTarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodUsuario",
                table: "HistoricoTarefa",
                column: "CodUsuario",
                principalTable: "Usuario",
                principalColumn: "CodUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

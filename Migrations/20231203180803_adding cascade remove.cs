using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eclipseworksteste.Migrations
{
    /// <inheritdoc />
    public partial class addingcascaderemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa",
                column: "CodHistorico",
                principalTable: "Tarefa",
                principalColumn: "CodTarefa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa",
                column: "CodHistorico",
                principalTable: "Tarefa",
                principalColumn: "CodTarefa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

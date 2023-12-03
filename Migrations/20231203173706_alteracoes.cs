using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eclipseworksteste.Migrations
{
    /// <inheritdoc />
    public partial class alteracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CodUsuario",
                table: "HistoricoTarefa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefa_CodUsuario",
                table: "HistoricoTarefa",
                column: "CodUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodUsuario",
                table: "HistoricoTarefa",
                column: "CodUsuario",
                principalTable: "Usuario",
                principalColumn: "CodUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodUsuario",
                table: "HistoricoTarefa");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoTarefa_CodUsuario",
                table: "HistoricoTarefa");

            migrationBuilder.DropColumn(
                name: "CodUsuario",
                table: "HistoricoTarefa");
        }
    }
}

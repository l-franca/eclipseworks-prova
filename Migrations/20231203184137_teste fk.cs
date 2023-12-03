using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eclipseworksteste.Migrations
{
    /// <inheritdoc />
    public partial class testefk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                table: "HistoricoTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodHistorico",
                table: "HistoricoTarefa");

            migrationBuilder.AlterColumn<long>(
                name: "CodHistorico",
                table: "HistoricoTarefa",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefa_CodTarefa",
                table: "HistoricoTarefa",
                column: "CodTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefa_CodUsuario",
                table: "HistoricoTarefa",
                column: "CodUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoTarefa_Tarefa_CodTarefa",
                table: "HistoricoTarefa",
                column: "CodTarefa",
                principalTable: "Tarefa",
                principalColumn: "CodTarefa",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_HistoricoTarefa_Tarefa_CodTarefa",
                table: "HistoricoTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoTarefa_Usuario_CodUsuario",
                table: "HistoricoTarefa");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoTarefa_CodTarefa",
                table: "HistoricoTarefa");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoTarefa_CodUsuario",
                table: "HistoricoTarefa");

            migrationBuilder.AlterColumn<long>(
                name: "CodHistorico",
                table: "HistoricoTarefa",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
    }
}

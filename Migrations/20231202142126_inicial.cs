using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eclipseworksteste.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CodUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Cargo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CodUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    CodProjeto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodUsuario = table.Column<long>(type: "bigint", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.CodProjeto);
                    table.ForeignKey(
                        name: "FK_Projeto_Usuario_CodUsuario",
                        column: x => x.CodUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    CodTarefa = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodProjeto = table.Column<long>(type: "bigint", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CodUsuario = table.Column<long>(type: "bigint", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Prioridade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.CodTarefa);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_CodProjeto",
                        column: x => x.CodProjeto,
                        principalTable: "Projeto",
                        principalColumn: "CodProjeto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuario_CodUsuario",
                        column: x => x.CodUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoTarefa",
                columns: table => new
                {
                    CodHistorico = table.Column<long>(type: "bigint", nullable: false),
                    CodTarefa = table.Column<long>(type: "bigint", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Comentario = table.Column<string>(type: "text", nullable: true),
                    StatusTarefa = table.Column<int>(type: "integer", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusHistorico = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoTarefa", x => x.CodHistorico);
                    table.ForeignKey(
                        name: "FK_HistoricoTarefa_Tarefa_CodHistorico",
                        column: x => x.CodHistorico,
                        principalTable: "Tarefa",
                        principalColumn: "CodTarefa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_CodUsuario",
                table: "Projeto",
                column: "CodUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CodProjeto",
                table: "Tarefa",
                column: "CodProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CodUsuario",
                table: "Tarefa",
                column: "CodUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoTarefa");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorriso_em_Jogo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habito",
                columns: table => new
                {
                    Id_habito = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Frequencia_ideal = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habito", x => x.Id_habito);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    Id_procedimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.Id_procedimento);
                });

            migrationBuilder.CreateTable(
                name: "Recompensa",
                columns: table => new
                {
                    Id_recompensa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Pontos_necessarios = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recompensa", x => x.Id_recompensa);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id_unidade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id_unidade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Data_cadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Pontos_recompensa = table.Column<float>(type: "BINARY_FLOAT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "ProcedimentosDaUnidade",
                columns: table => new
                {
                    UnidadeId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProcedimentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedimentosDaUnidade", x => new { x.UnidadeId, x.ProcedimentoId });
                    table.ForeignKey(
                        name: "FK_ProcedimentosDaUnidade_Procedimento_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimento",
                        principalColumn: "Id_procedimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedimentosDaUnidade_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id_unidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id_feedback = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Comentario = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id_feedback);
                    table.ForeignKey(
                        name: "FK_Feedback_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroHabito",
                columns: table => new
                {
                    Id_habito = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Imagem = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Observacoes = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HabitoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroHabito", x => x.Id_habito);
                    table.ForeignKey(
                        name: "FK_RegistroHabito_Habito_HabitoId",
                        column: x => x.HabitoId,
                        principalTable: "Habito",
                        principalColumn: "Id_habito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroHabito_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioColetandoRecompensa",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecompensaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataColeta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioColetandoRecompensa", x => new { x.UsuarioId, x.RecompensaId });
                    table.ForeignKey(
                        name: "FK_UsuarioColetandoRecompensa_Recompensa_RecompensaId",
                        column: x => x.RecompensaId,
                        principalTable: "Recompensa",
                        principalColumn: "Id_recompensa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioColetandoRecompensa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UsuarioId",
                table: "Feedback",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentosDaUnidade_ProcedimentoId",
                table: "ProcedimentosDaUnidade",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroHabito_HabitoId",
                table: "RegistroHabito",
                column: "HabitoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroHabito_UsuarioId",
                table: "RegistroHabito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioColetandoRecompensa_RecompensaId",
                table: "UsuarioColetandoRecompensa",
                column: "RecompensaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "ProcedimentosDaUnidade");

            migrationBuilder.DropTable(
                name: "RegistroHabito");

            migrationBuilder.DropTable(
                name: "UsuarioColetandoRecompensa");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Habito");

            migrationBuilder.DropTable(
                name: "Recompensa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

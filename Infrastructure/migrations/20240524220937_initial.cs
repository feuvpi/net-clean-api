using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_manegement_api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competicao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    IdadeLimite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeAdversario = table.Column<string>(type: "text", nullable: false),
                    DataHorario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Local = table.Column<string>(type: "text", nullable: false),
                    CompeticaoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Competicao_CompeticaoId",
                        column: x => x.CompeticaoId,
                        principalTable: "Competicao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partida_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Dominancia = table.Column<string>(type: "text", nullable: false),
                    Minutagem = table.Column<int>(type: "integer", nullable: false),
                    Gols = table.Column<int>(type: "integer", nullable: false),
                    Assistencias = table.Column<int>(type: "integer", nullable: false),
                    CartoesAmarelos = table.Column<int>(type: "integer", nullable: false),
                    CartoesVermelhos = table.Column<int>(type: "integer", nullable: false),
                    PartidaId = table.Column<Guid>(type: "uuid", nullable: true),
                    TimeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atletas_Partida_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partida",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atletas_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExamesMedicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    AtletaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: false),
                    Anexo = table.Column<byte[]>(type: "bytea", nullable: false),
                    DocumentUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamesMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamesMedicos_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AtletaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartidaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gols_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gols_Partida_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_PartidaId",
                table: "Atletas",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_TimeId",
                table: "Atletas",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamesMedicos_AtletaId",
                table: "ExamesMedicos",
                column: "AtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gols_AtletaId",
                table: "Gols",
                column: "AtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gols_PartidaId",
                table: "Gols",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_CompeticaoId",
                table: "Partida",
                column: "CompeticaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_TimeId",
                table: "Partida",
                column: "TimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamesMedicos");

            migrationBuilder.DropTable(
                name: "Gols");

            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Competicao");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}

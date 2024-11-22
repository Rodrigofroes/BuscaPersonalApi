using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuscaPersonalApi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academia",
                columns: table => new
                {
                    Aca_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Aca_nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_cnpj = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_estado = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_cep = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_telefone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aca_confirmado = table.Column<bool>(type: "boolean", nullable: false),
                    Aca_ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Aca_data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academia", x => x.Aca_id);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Per_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Per_nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Per_cpf = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Per_cref = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Per_telefone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Per_especialidades = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Per_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Per_senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Per_confirmado = table.Column<bool>(type: "boolean", nullable: false),
                    Per_ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Per_data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Per_id);
                });

            migrationBuilder.CreateTable(
                name: "AcademiaPersonal",
                columns: table => new
                {
                    Acaper_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Aca_id = table.Column<int>(type: "integer", nullable: false),
                    Per_id = table.Column<int>(type: "integer", nullable: false),
                    Acaper_ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Acaper_data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AcademiaAca_id = table.Column<int>(type: "integer", nullable: false),
                    PersonalPer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademiaPersonal", x => x.Acaper_id);
                    table.ForeignKey(
                        name: "FK_AcademiaPersonal_Academia_AcademiaAca_id",
                        column: x => x.AcademiaAca_id,
                        principalTable: "Academia",
                        principalColumn: "Aca_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademiaPersonal_Personal_PersonalPer_id",
                        column: x => x.PersonalPer_id,
                        principalTable: "Personal",
                        principalColumn: "Per_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaPersonal_AcademiaAca_id",
                table: "AcademiaPersonal",
                column: "AcademiaAca_id");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaPersonal_PersonalPer_id",
                table: "AcademiaPersonal",
                column: "PersonalPer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademiaPersonal");

            migrationBuilder.DropTable(
                name: "Academia");

            migrationBuilder.DropTable(
                name: "Personal");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio.Migrations
{
    /// <inheritdoc />
    public partial class consultorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    cpf = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    dtnascimento = table.Column<DateTime>(name: "dt_nascimento", type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pacientes", x => x.cpf);
                });

            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpfpaciente = table.Column<long>(name: "cpf_paciente", type: "bigint", nullable: false),
                    datahorainicial = table.Column<DateTime>(name: "data_hora_inicial", type: "timestamp", nullable: false),
                    datahorafinal = table.Column<DateTime>(name: "data_hora_final", type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_consultas", x => x.id);
                    table.ForeignKey(
                        name: "fk_consultas_pacientes_cpf_paciente",
                        column: x => x.cpfpaciente,
                        principalTable: "pacientes",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_consultas_cpf_paciente",
                table: "consultas",
                column: "cpf_paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultas");

            migrationBuilder.DropTable(
                name: "pacientes");
        }
    }
}

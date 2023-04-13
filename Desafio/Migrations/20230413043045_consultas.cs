using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio.Migrations
{
    /// <inheritdoc />
    public partial class consultas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpfpaciente = table.Column<long>(name: "cpf_paciente", type: "bigint", nullable: false),
                    datahorainicial = table.Column<DateTime>(name: "data_hora_inicial", type: "Timestamp without Time Zone", nullable: false),
                    datahorafinal = table.Column<DateTime>(name: "data_hora_final", type: "Timestamp without Time Zone", nullable: false),
                    tempoconsulta = table.Column<TimeSpan>(name: "tempo_consulta", type: "Interval", nullable: false, computedColumnSql: "AGE(data_hora_final, data_hora_inicial)", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_consultas", x => x.id);
                    table.ForeignKey(
                        name: "fk_consultas_pacientes_paciente_temp_id",
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
        }
    }
}

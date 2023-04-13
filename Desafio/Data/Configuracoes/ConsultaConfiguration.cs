using Desafio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Configuracoes
{
    public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataHoraInicial)
                .HasColumnType("Timestamp without Time Zone")
                .IsRequired();

            builder.Property(c => c.DataHoraFinal)
                .HasColumnType("Timestamp without Time Zone")
                .IsRequired();
            
            var sql = "AGE(data_hora_final, data_hora_inicial)";

            builder.Property(c => c.TempoConsulta)
                .HasColumnType("Interval")                
                .HasComputedColumnSql(sql, true);

            builder.HasOne(c => c.Paciente)
                   .WithMany(p => p.Consultas)
                   .HasForeignKey(c => c.CPFPaciente);
        }
    }
}

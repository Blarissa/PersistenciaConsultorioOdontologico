using Desafio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Configuracoes
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.Property(p => p.CPF)
                .ValueGeneratedNever();
            
            builder.HasKey(p => p.CPF);

            builder.Property(p => p.Nome)
                .IsRequired();

            builder.Property(p => p.DataDeNascimento)
                .HasColumnType("Date")
                .IsRequired();                                  
        }
    }
}

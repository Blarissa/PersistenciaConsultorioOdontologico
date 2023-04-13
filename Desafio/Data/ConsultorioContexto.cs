using Desafio.Data.Configuracoes;
using Desafio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data
{
    #region Documentation
    /// <summary>
    ///     Define o a classe <see cref="ConsultorioContexto"/> que realiza a integração com o banco
    ///     de dados <see langword="ConsultorioDB"/>.
    /// </summary>
    #endregion

    public class ConsultorioContexto : DbContext
    {
        #region Documentation
        /// <summary>  
        ///     Propriedade referente a tabela <see langword="Pacientes"/> do banco de dados <see langword="ConsultorioDB"/>.
        /// </summary>
        #endregion

        public DbSet<Paciente> Pacientes { get; set; }

        #region Documentation
        /// <summary>
        ///     Propriedade referente a tabela <see langword="Consultas"/> do banco de dados<see langword="ConsultorioDB"/>.
        /// </summary>
        #endregion

        public DbSet<Consulta> Consultas { get; set; }

        #region Documentation
        /// <summary>
        ///     Método sobrescrico que realiza a configuração do banco de dados que vai ser usado nesse contexto.
        /// </summary>  
        ///
        /// <param name="optionsBuilder">
        ///     Um construtor usado para criar ou modificar opções para este contexto.
        /// </param>
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            var host = new DBConfig().Host;
            var user =  new DBConfig().User;
            var database = new DBConfig().Database;
            var senha = new DBConfig().Senha;

            string url = $"Host={host};Username={user};Password={senha};Database={database}";

            optionsBuilder
                .UseNpgsql(@url)
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                                
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultaConfiguration());
        }
    }
}

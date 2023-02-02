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
    /// <summary>   Define a classe de configuração do banco de dados. </summary>
    #endregion

    internal class ConsultorioContexto : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        #region Documentation
        /// <summary>
        ///     Método sobreescrito para configurar o banco de dados e ser usado para esse contexto.
        /// </summary>
        ///
        /// <param name="optionsBuilder">
        ///     Um construtor usado para criar ou modificar opções para esse contexto.
        /// </param>
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = new DBConfig().Host;
            var user = new DBConfig().User;
            var database = new DBConfig().Database;
            var senha = new DBConfig().Senha;

            string url = $"Host={host};Username={user};Password={senha};Database={database}";
            optionsBuilder
                .UseNpgsql(@url)
                .UseSnakeCaseNamingConvention();
        }
    }
}

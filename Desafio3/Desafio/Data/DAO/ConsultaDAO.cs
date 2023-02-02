using Desafio.Model;
using Desafio.View;

namespace Desafio.Data.DAO
{
    #region Documentation
    /// <summary>   
    ///     Define a classe <see cref="ConsultaDAO" /> que realiza modificações na tabela <see cref="ConsultorioContexto.ConsultorioContexto" >
    ///     consultas</see> do banco de dados.
    /// </summary>
    #endregion

    internal class ConsultaDAO : IComando<Consulta>
    {
        ConsultorioContexto contexto;

        #region Documentation
        /// <summary>   Inicia a instanciação da classe <see cref="ConsultaDAO" />. </summary>
        ///
        /// <param name="contexto"> Referente a propriedade do <see cref="ConsultorioContexto" />. </param>
        #endregion

        public ConsultaDAO(ConsultorioContexto contexto)
        {
            this.contexto = contexto;
        }

        #region Documentation
        /// <summary>   Adiciona uma <see cref="Consulta" /> no banco de dados. </summary>        
        /// 
        /// <param name="consulta"> Referente a um objeto de <see cref="Consulta" />. </param>
        #endregion

        public void Adicionar(Consulta consulta)
        {
            contexto.Consultas.Add(consulta);
            contexto.SaveChanges();
        }

        #region Documentation
        /// <summary>
        ///     Lista todas as <see cref="ConsultorioContexto.Consultas">consultas</see> cadastradas no
        ///     banco de dados.
        /// </summary>
        ///
        /// <returns>
        ///     Uma <see cref="IEnumerable"/>  com todas as <see cref="ConsultorioContexto.Consultas">
        ///     consultas</see>  cadastradas.
        /// </returns>
        #endregion

        public IEnumerable<Consulta> ListarTodos()
        {
            return contexto.Consultas.ToList();

        }

        #region Documentation
        /// <summary>
        ///     Lista uma <see cref="Consulta">consulta</see> do banco de dados de acordo com seu <paramref name="id"/>.
        /// </summary>
        ///
        /// <param name="id">
        ///     Referente ao <see cref="Consulta.Id">ID</see> da <see cref="Consulta">consulta</see>.
        /// </param>
        ///
        /// <returns>   Uma <see cref="Consulta">consulta</see>. </returns>
        #endregion

        public Consulta ListarPorId(int id)
        {
            return contexto.Consultas.Find(id);
        }

        #region Documentation
        /// <summary>   Remove Uma <see cref="Consulta">consulta</see> do banco de dados. </summary>
        /// 
        /// <param name="paciente"> Referente a um objeto de <see cref="Consulta" />. </param>
        #endregion

        public void Remover(Consulta consulta)
        {
            contexto.Consultas.Remove(consulta);

            Program.ExibeEntries(contexto.ChangeTracker.Entries());
            contexto.SaveChanges();
        }
    }
}
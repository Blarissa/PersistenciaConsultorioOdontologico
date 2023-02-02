using Desafio.Model;
using Desafio.View;
using System.Collections;

namespace Desafio.Data.DAO
{
    #region Documentation
    /// <summary>
    ///     Define a classe <see cref="PacienteDAO" /> que realiza modificações na tabela <see cref="ConsultorioContexto.Pacientes" >
    ///     pacientes</see> do banco de dados.
    /// </summary>
    #endregion

    internal class PacienteDAO : IComando<Paciente>
    {
        ConsultorioContexto contexto;

        #region Documentation
        /// <summary>   Inicia a instanciação da classe <see cref="PacienteDAO" />. </summary>
        ///
        /// <param name="contexto"> Referente a propriedade do <see cref="ConsultorioContexto" />. </param>
        #endregion

        public PacienteDAO(ConsultorioContexto contexto)
        {
            this.contexto = contexto;
        }

        #region Documentation
        /// <summary>   Adiciona um <see cref="Paciente" /> no banco de dados. </summary>        
        /// 
        /// <param name="paciente"> Referente a um objeto de <see cref="Paciente" />. </param>
        #endregion

        public void Adicionar(Paciente paciente)
        {
            contexto.Pacientes.Add(paciente);
            contexto.SaveChanges();
            Program.ExibeEntries(contexto.ChangeTracker.Entries());
        }

        #region Documentation
        /// <summary>   Remove um <see cref="Paciente">paciente</see> do banco de dados. </summary>
        /// 
        /// <param name="paciente"> Referente a um objeto de <see cref="Paciente" />. </param>
        #endregion

        public void Remover(Paciente paciente)
        {
            contexto.Pacientes.Remove(paciente);
            contexto.SaveChanges();
            Program.ExibeEntries(contexto.ChangeTracker.Entries());
        }

        #region Documentation
        /// <summary>
        ///     Lista todos os <see cref="ConsultorioContexto.Pacientes">pacientes</see> cadastrados no
        ///     banco de dados.
        /// </summary>
        ///
        /// <returns>
        ///     Uma <see cref="IEnumerable"/>  com todos os <see cref="ConsultorioContexto.Pacientes">
        ///     pacientes</see>  cadastrados.
        /// </returns>
        #endregion

        public IEnumerable<Paciente> ListarTodos()
        {
            return contexto.Pacientes.ToList();
        }

        #region Documentation
        /// <summary>
        ///     Lista um <see cref="Paciente">paciente</see> do banco de dados de acordo com seu <paramref name="cpf"/>
        ///     .
        /// </summary>
        ///
        /// <param name="cpf">
        ///     Referente ao <see cref="Paciente.CPF">CPF</see> do <see cref="Paciente">paciente</see>.
        /// </param>
        ///
        /// <returns>   Um <see cref="Paciente">paciente</see>. </returns>
        #endregion

        public Paciente ListarPorCPF(long cpf)
        {
            return contexto.Pacientes.Find(cpf);
        }
    }
}

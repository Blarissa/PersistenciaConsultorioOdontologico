using Desafio.Model;

namespace Desafio.Data.DAO
{
    #region Documentation
    /// <summary>
    ///     Define a classe <see cref="PacienteDAO" /> que utiliza a tabela <see cref="ConsultorioContexto.Pacientes" />
    ///     do banco de dados.
    /// </summary>
    #endregion

    public class PacienteDAO : IDAO<Paciente>
    {
        ConsultorioContexto contexto;

        #region Documentation
        /// <summary>   Inicializa uma inst�ncia da classe <see cref="PacienteDAO" />. </summary>
        ///
        /// <param name="contexto"> Referente a um objeto do <see cref="ConsultorioContexto" />. </param>
        #endregion

        public PacienteDAO(ConsultorioContexto contexto) { 
            this.contexto = contexto;
        }

        #region Documentation
        /// <summary>   Realiza a adi��o de um <see cref="Paciente" /> do banco de dados. </summary>
        ///
        /// <param name="paciente"> Representa um objeto do <see cref="Paciente" />. </param>
        #endregion

        public void Adicionar(Paciente paciente)
        {
            contexto.Pacientes.Add(paciente);
            contexto.SaveChanges();
        }

        #region Documentation
        /// <summary>   Realiza a remo��o de um <see cref="Paciente" /> do banco de dados. </summary>
        ///
        /// <param name="paciente"> Representa um objeto do <see cref="Paciente" />. </param>
        #endregion

        public void Remover(Paciente paciente)
        {
            contexto.Pacientes.Remove(paciente);
            contexto.SaveChanges();
        }

        #region Documentation
        /// <summary>
        ///     Realiza a listagem de todos os <see cref="Paciente">Pacientes</see> da lista.
        /// </summary>
        ///
        /// <returns>   Uma <see cref="IList{T}"/> do tipo <see cref="Paciente" />. </returns>
        #endregion

        public IList<Paciente> ListaTodos()
        {
            return contexto.Pacientes.ToList();
        }

        #region Documentation
        /// <summary>
        ///     Realiza a listagem de um <see cref="Paciente" /> com o CPF igual ao <paramref name="cpf"/>.
        /// </summary>
        ///
        /// <param name="cpf">  Referente a propriedade <see cref="Paciente.CPF"/>. </param>
        ///
        /// <returns>
        ///     <list type="bullet">
        ///       <item>Se o <see cref="Paciente" /> existir retorna o <see cref="Paciente" /> que tem
        ///       CPF igual ao <paramref name="cpf"/>.</item>
        ///       <item>Caso contr�rio, retorna um <see cref="Paciente" /> <see langword="null"/>.</item>
        ///     </list>
        /// </returns>
        #endregion

        public Paciente? ListaPorCPF(long cpf)
        {
            return contexto.Pacientes
                .FirstOrDefault(p => p.CPF == cpf);
        }       
    }
}

using Desafio.Data.DAO;
using Desafio.Model;
using Desafio.Data;

namespace Desafio.Controller
{
    #region Documentation
    /// <summary>   Define o controlador da classe <see cref="Paciente"/>. </summary>
    #endregion

    public class PacienteController : IController
    {
        PacienteDAO dao;
        private EntradaDeDados Input { get; set; }
        public PacienteController(IRecebimentoDeDados entrada, ValidacaoController validacao, ConsultorioContexto DBCtxt)
        {
            Input = new EntradaDeDados(entrada, validacao);
            dao = new(DBCtxt);
        }

        #region Documentation
        /// <summary>
        ///     Realiza adição de um <see cref="Paciente"/> com dados inseridos pelo console e válidos.
        /// </summary>       
        #endregion

        public void Adiciona()
        {
            long CPF = Input.RetornaCPF();   
            string nome = Input.RetornaNome();
            DateTime data = Input.RetornaData(TipoDeData.DataDeNascimento);

            dao.Adicionar(
                new Paciente() { 
                    CPF = CPF, 
                    Nome = nome, 
                    DtNascimento = data
                });
        }

        #region Documentation
        /// <summary>   Realiza a remoção de um <see cref="Paciente"/>. </summary>       
        #endregion

        public void Remove()
        {
            long CPF = Input.RetornaCPF();
            var paciente = dao.ListaPorCPF(CPF);

            dao.Remover(paciente);
        }        

        #region Documentation
        /// <summary>
        ///     Realiza listagem dos <see cref="Paciente">pacientes</see> ordenados por <see cref="Paciente.CPF"/>.      
        /// </summary>
        #endregion

        public void ListarOrdenadosPorCPF()
        {
            var pacientes = dao.ListaTodos();
            var query = from p in pacientes orderby p.CPF select p;

            Console.WriteLine(Paciente.Listar(query.ToList()));
        }

        #region Documentation
        /// <summary>
        ///     Realiza listagem dos <see cref="Paciente">pacientes</see> ordenados por <see cref="Paciente.Nome"/>.        
        /// </summary>
        #endregion

        public void ListarOrdenadosPorNome()
        {
            var pacientes = dao.ListaTodos();
            var query = from p in pacientes orderby p.Nome select p;

            Console.WriteLine(Paciente.Listar(query.ToList()));
        }

        #region Documentation
        /// <summary >  Realiza listagem de um <see cref="Paciente"/>. </summary>
        #endregion

        public void ListarPorChave()
        {
            long CPF = Input.RetornaCPF();
            var paciente = dao.ListaPorCPF(CPF);

            Console.WriteLine(paciente);
        }        
    }
}

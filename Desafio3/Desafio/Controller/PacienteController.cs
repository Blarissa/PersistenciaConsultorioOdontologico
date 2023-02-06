using Desafio.Data.DAO;
using Desafio.Model;

namespace Desafio.Controller
{
    #region Documentation
    /// <summary>   Define o controlador da classe <see cref="Paciente"/>. </summary>
    #endregion

    public class PacienteController : IController
    {
        PacienteDAO dao;

        #region Documentation
        /// <summary>
        ///     Realiza adição de um <see cref="Paciente"/> com dados inseridos pelo console e válidos.
        /// </summary>       
        #endregion

        public void Adiciona()
        {
            long CPF = EntradaDeDados.RetornaCPF();   
            string nome = EntradaDeDados.RetornaNome();
            DateTime data = EntradaDeDados.RetornaData(0);

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
            long CPF = EntradaDeDados.RetornaCPF();
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
            long CPF = EntradaDeDados.RetornaCPF();
            var paciente = dao.ListaPorCPF(CPF);

            Console.WriteLine(paciente);
        }        
    }
}

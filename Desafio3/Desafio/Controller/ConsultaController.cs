using Desafio.Data.DAO;
using Desafio.Model;

namespace Desafio.Controller
{
    #region Documentation
    /// <summary>   Define o controlador da classe <see cref="Consulta"/>. </summary>
    #endregion

    public class ConsultaController : IController
    {
        ConsultaDAO consultaDAO;
        PacienteDAO pacienteDAO;

        #region Documentation
        /// <summary>   Realiza o agendamento de uma <see cref="Consulta"/>. </summary>
        #endregion

        public void Adiciona()
        {
            var CPF = EntradaDeDados.RetornaCPF();
            var paciente = pacienteDAO.ListaPorCPF(CPF);

            var data = EntradaDeDados.RetornaData(1);
            var dataHoraInicial = data + EntradaDeDados.RetornaData(4).TimeOfDay;
            var dataHoraFinal = data + EntradaDeDados.RetornaData(5).TimeOfDay;

            consultaDAO.Adicionar(new Consulta() {
                CPFPaciente = CPF,
                Paciente = paciente,
                DataHoraInicial = dataHoraInicial,
                DataHoraFinal = dataHoraFinal
            }) ;
        }

        #region Documentation
        /// <summary>   Realiza a listagem de uma <see cref="Consulta"/>. </summary>
        #endregion

        public void ListarPorChave()
        {
            var CPF = EntradaDeDados.RetornaCPF();
            var DataHora = EntradaDeDados.RetornaData(1);
            DataHora +=  EntradaDeDados.RetornaData(4).TimeOfDay;            

            var query = from c in consultaDAO.ListaTodos()
                        where c.CPFPaciente.Equals(CPF) &&
                        c.DataHoraInicial.Equals(DataHora) 
                        select c;

            var consulta = consultaDAO.ListaPorId(query.First().Id);

            Console.WriteLine(consulta);
        }

        #region Documentation
        /// <summary>   Realiza a listagem de todas as <see cref="Consulta">consultas</see>. </summary>
        #endregion

        public void ListarTodos()
        {
            var consultas = consultaDAO.ListaTodos();

            Console.WriteLine(consultas);
        }

        #region Documentation
        /// <summary>   Realiza a remoção de uma <see cref="Consulta"/>. </summary>
        #endregion

        public void Remove()
        {
            var CPF = EntradaDeDados.RetornaCPF();
            var DataHora = EntradaDeDados.RetornaData(1);
            DataHora += EntradaDeDados.RetornaData(4).TimeOfDay;

            var query = from c in consultaDAO.ListaTodos()
                        where c.CPFPaciente.Equals(CPF) &&
                        c.DataHoraInicial.Equals(DataHora)
                        select c;

            var consulta = consultaDAO.ListaPorId(query.First().Id);
            consultaDAO.Remover(consulta);
        }
    }
}


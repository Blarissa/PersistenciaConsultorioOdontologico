using Desafio.Data;
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
        ConsultorioContexto contexto = new ConsultorioContexto();

        public ConsultaController()
        {
            consultaDAO = new ConsultaDAO(contexto);
            pacienteDAO = new PacienteDAO(contexto);
        }

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

            consultaDAO.Adicionar(new Consulta()
            {
                CPFPaciente = CPF,
                Paciente = paciente,
                DataHoraInicial = dataHoraInicial,
                DataHoraFinal = dataHoraFinal
            });
        }

        #region Documentation
        /// <summary>   Realiza a listagem de uma <see cref="Consulta"/>. </summary>
        #endregion

        public void ListarPorChave()
        {
            var CPF = EntradaDeDados.RetornaCPF();
            var DataHora = EntradaDeDados.RetornaData(1);
            DataHora += EntradaDeDados.RetornaData(4).TimeOfDay;

            var id = RetornaID(CPF, DataHora);

            var consulta = consultaDAO.ListaPorId(id);

            Console.WriteLine(consulta);
        }

        #region Documentation
        /// <summary>   Realiza a listagem de todas as <see cref="Consulta">consultas</see>. </summary>
        #endregion

        public void ListarTodos()
        {
            var opcao = EntradaDeDados.RetornaOpcaoDeListagemDaAgenda();
            var consultas = consultaDAO.ListaTodos();

            if (opcao == 'P')
            {
                var dataInicial = EntradaDeDados.RetornaData(2);
                var dataFinal = EntradaDeDados.RetornaData(3);

                var query = from c in consultas
                            where c.DataHoraInicial.Date >= dataInicial ||
                            c.DataHoraFinal.Date <= dataFinal
                            select c;
                consultas = query.ToList();
            }

            Console.WriteLine(Consulta.Listar(consultas));
        }

        #region Documentation
        /// <summary>   Realiza a remoção de uma <see cref="Consulta"/>. </summary>
        #endregion

        public void Remove()
        {
            var CPF = EntradaDeDados.RetornaCPF();
            var DataHora = EntradaDeDados.RetornaData(1);
            DataHora += EntradaDeDados.RetornaData(4).TimeOfDay;
            var id = RetornaID(CPF, DataHora);

            var consulta = consultaDAO.ListaPorId(id);
            consultaDAO.Remover(consulta);
        }

        internal IList<Consulta> ListarPorCPF(long CPF)
        {
            return consultaDAO.ListaPorCPF(CPF);
        }

        private int RetornaID(long CPF, DateTime DataHora)
        {
            var query = from c in consultaDAO.ListaTodos()
                        where c.CPFPaciente.Equals(CPF) &&
                        c.DataHoraInicial.Equals(DataHora)
                        select c;

            return query.First().Id;
        }
    }
}


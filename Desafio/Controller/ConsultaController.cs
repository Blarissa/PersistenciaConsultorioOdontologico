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
        private ConsultaDAO CnsltDAO { get; set; }
        private PacienteDAO PcteDAO { get; set; }

        private EntradaDeDados Input { get; set; }
        public ConsultaController(IRecebimentoDeDados entrada, ValidacaoController val, ConsultorioContexto DBCtxt)
        {
            Input = new EntradaDeDados(entrada, val);
            CnsltDAO = new(DBCtxt);
            PcteDAO = new(DBCtxt);
        }

        #region Documentation
        /// <summary>   Realiza o agendamento de uma <see cref="Consulta"/>. </summary>
        #endregion

        public void Adiciona()
        {
            var CPF = Input.RetornaCPF();
            var paciente = PcteDAO.ListaPorCPF(CPF);

            var data = Input.RetornaData(TipoDeData.DataConsulta);
            var dataHoraInicial = Input.RetornaHoraInicial(TipoDeHora.HoraInicial, data);
            var dataHoraFinal = Input.RetornaHoraFinal(data,dataHoraInicial);


            CnsltDAO.Adicionar(new Consulta() {
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
            var CPF = Input.RetornaCPF();
            var DataHora = Input.RetornaData(TipoDeData.DataInicialPeriodo);
            DataHora += Input.RetornaData(TipoDeData.DataConsulta).TimeOfDay;

            var query = from c in CnsltDAO.ListaTodos()
                        where c.CPFPaciente.Equals(CPF) &&
                        c.DataHoraInicial.Equals(DataHora)
                        select c;

            var consulta = CnsltDAO.ListaPorId(query.First().Id);

            Console.WriteLine(consulta);
        }

        #region Documentation
        /// <summary>   Realiza a listagem de todas as <see cref="Consulta">consultas</see>. </summary>
        #endregion

        public void ListarTodos()
        {
            var opcao = Input.RetornarOpcaoListAgenda();
            var consultas = CnsltDAO.ListaTodos();

            if (opcao == 'P' || opcao == 'p')
            {
                var dataInicial = Input.RetornaData(TipoDeData.DataInicialPeriodo);
                var dataFinal = Input.RetornaDataFinal(dataInicial);

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
            var CPF = Input.RetornaCPF();
            var Data = Input.RetornaData(TipoDeData.DataConsulta);
            var HorarioConsulta = Input.RetornaHoraInicial(TipoDeHora.HoraInicial, Data);

            var query = from c in CnsltDAO.ListaTodos()
                        where c.CPFPaciente.Equals(CPF) &&
                        c.DataHoraInicial.Equals(HorarioConsulta)
                        select c;

            var consulta = CnsltDAO.ListaPorId(query.First().Id);
            CnsltDAO.Remover(consulta);
        }
    }
}


using Desafio.Desafio.Models;
using Desafio.Desafio.View;

namespace Desafio.Desafio.Controllers
{
    /// <summary>
    /// Define uma <see cref="Agenda"/> com <see cref="Consulta"/> de um consultório odontológico.
    /// </summary>
    public class Agenda
    {
        /// <summary>
        /// The consultas.
        /// </summary>
        public List<Consulta> Consultas = new();
        /// <summary>
        /// The agendamentos.
        /// </summary>
        List<DateTime> agendamentos = new();
        /// <summary>
        /// Gets the agendamentos.
        /// </summary>
        public List<DateTime> Agendamentos
        {
            get {
                Consultas.ForEach(c => agendamentos.Add(c.DtConsulta));
                return agendamentos;
            }
        }

        /// <summary>
        /// Ordena <see cref="Consultas"/> pela <c>data de consulta</c>
        /// </summary>        
        public Agenda()
        {
            Consultas = Consultas.OrderBy(c => c.DtConsulta).ToList();
        }

        /// <summary>
        /// Realiza o agendamento de uma consulta.
        /// </summary>
        /// <remarks>
        /// A classe <see cref="EntradaDeDados"/> é chamada e realiza a leitura dos 
        /// dados necessários para realizar o agendamento de uma consulta.
        /// <para>
        /// Caso algum dado seja inválido, aparecerá uma mensagem de erro e o dado 
        /// será solicitado novamente.
        /// </para>
        /// </remarks>
        public void Agendar()
        {
            long CPF = EntradaDeDados.LerCPF();
            //verifica se paciente está cadastrado
            if (!new PacienteController().PacienteExiste(CPF))
            {
                Console.WriteLine(Menssagens.PacienteInixistente);
                CPF = EntradaDeDados.LerCPF();
            }

            DateTime data = EntradaDeDados.LerDtConsulta();
            DateTime hrInicial = EntradaDeDados.LerHrInicial();
            DateTime hrFinal = EntradaDeDados.LerHrFinal(hrInicial.ToString("HHmm"));

            Consultas.Add(new Consulta(CPF, data, hrInicial, hrFinal));
            Console.WriteLine(Menssagens.AgendamentoRealizado);
        }

        /// <summary>
        /// Pesquisa uma <see cref="Consulta"/> em <see cref="Consultas"/>.
        /// </summary>
        ///<param name = "CPF">Representa o valor da propriedade <see cref="Consulta.CPF"/>, deve possuir o valor de um CPF cadastrado na lista de Pacientes.</param>
        ///<param name = "dtConsulta">Representa o valor da propriedade <see cref="Consulta.DtConsulta" />, deve possuir o formato DD/MM/AAAA.</param>
        ///<param name = "hrInicial">Representa o valor da propriedade <see cref="Consulta.HrInicial" />, deve possuir o formato HHMM, estar no limite do horário de funcionamento do consultório, 8:00h às 19:00h, e ser definida sempre de 15 em 15 minutos(Ex. 1400, 1730, 1615).</param>
        ///<returns>
        ///<list type="bullet">
        ///<item>
        ///Retorna <see langword="null"/> caso a <see cref="Consulta"/> pesquisada não exista.
        ///</item>
        ///<item>
        ///Retorna a <see cref="Consulta"/> que tem <see cref="Consulta.CPF"/>, <see cref="Consulta.DtConsulta"/>, <see cref= "Consulta.HrInicial"/> iguais aos passados nos parâmetros do método.
        ///</item>
        ///</list>
        ///</returns>
        public Consulta? PesquisaConsulta(long CPF, DateTime dtConsulta, DateTime hrInicial)
        {
            if (ConsultaExiste(CPF, dtConsulta, hrInicial))
                return Consultas.Find(consulta => consulta.CPF.Equals(CPF) &&
                       consulta.DtConsulta.Date.Equals(dtConsulta.Date) &&
                       consulta.HrInicial.TimeOfDay.Equals(hrInicial.TimeOfDay));
            return null;
        }

        /// <summary>
        /// Pesquisa uma <see cref="Consulta"/> na <see cref="Consultas"/> que estão em um determinado intervalo de tempo.
        /// </summary>
        ///<param name = "dtInicial">Representa o valor da <see langword="dtInicial"/> do intervalo de tempo e deve possuir deve possuir o formato DD/MM/AAAA.</param>
        ///<param name = "dtFinal">Representa o valor da <see langword="dtFinal"/> do intervalo de tempo, deve possuir deve possuir o formato DD/MM/AAAA e ser maior que <see langword="dtInicial"/></param>       
        ///<returns>
        ///Retorna <see cref="List{Consulta}"/> com todas as consultas agendadas entre <see langword="dtInicial"/> e <see langword="dtFinal"/>
        ///</returns>
        public List<Consulta> PesquisaConsultasPeriodo(DateTime dtInicial, DateTime dtFinal)
        {
            return Consultas.FindAll(
                   consulta => consulta.DtConsulta >= dtInicial &&
                                consulta.DtConsulta <= dtFinal);
        }
        ///<summary>
        ///Determina se existe uma <see cref="Consulta"/> na <see cref="Consultas"/>.
        ///</summary>
        ///<returns>
        ///Retorna <see langword="true"/> se existir alguma <see cref="Consulta"/> onde <see cref="Consulta.CPF"/>, <see cref="Consulta.DtConsulta"/>, 
        ///<br><see cref= "Consulta.HrInicial"/> iguais aos passados nos parâmetros do método.</br>
        ///</returns>
        public bool ConsultaExiste(long CPF, DateTime dtConsulta, DateTime hrInicial)
        {
            return Consultas.Exists(consulta => consulta.CPF.Equals(CPF) &&
                                    consulta.DtConsulta.Date.Equals(dtConsulta.Date) &&
                                    consulta.HrInicial.TimeOfDay.Equals(hrInicial.TimeOfDay));
        }

        /// <summary>
        /// Pesquisa um <see cref="Paciente"/> na <see cref="Consultas"/>.
        /// </summary>
        ///<returns>
        ///Retorna <see cref="List{Consulta}"/> com todas as <see cref="Consulta"/> do <see cref="Paciente"/> que tem <see cref="Paciente.CPF"/> igual ao passado por parâmetro.
        ///</returns>
        public List<Consulta> PesquisaConsultasPorCPF(long CPF)
        {
            return Consultas.FindAll(c => c.CPF.Equals(CPF));
        }

        /// <summary>
        /// Cancela uma <see cref="Consulta"/> da <see cref="Consultas"/>.
        /// </summary>
        /// <remarks>
        /// A classe <see cref="EntradaDeDados"/> é chamada e realiza a leitura dos 
        /// dados necessários para realizar o cancelamento de uma consulta.
        /// <para>
        /// Caso algum dado seja inválido, aparecerá uma mensagem de erro e o dado 
        /// será solicitado novamente.
        /// </para>
        /// </remarks>       
        public void Cancelar()
        {
            long CPF = EntradaDeDados.LerCPF();
            DateTime dtConsulta = EntradaDeDados.LerDtConsulta();
            DateTime hrInicial = EntradaDeDados.LerHrInicial();

            while (!ConsultaExiste(CPF, dtConsulta, hrInicial))
            {
                Console.WriteLine(Menssagens.AgendInexistente);
                CPF = EntradaDeDados.LerCPF();
                dtConsulta = EntradaDeDados.LerDtConsulta();
                hrInicial = EntradaDeDados.LerHrInicial();
            }
            
            Consulta consulta = PesquisaConsulta(CPF, dtConsulta, hrInicial);
            
            //Se consulta agendada for de um período futuro pode cancelar
            if (consulta.DtConsulta > DateTime.Now ||
                consulta.DtConsulta.Equals(DateTime.Now) &&
                consulta.HrInicial.TimeOfDay > DateTime.Now.TimeOfDay)
            {
                Consultas.Remove(PesquisaConsulta(CPF, dtConsulta, hrInicial));
                Console.WriteLine(Menssagens.AgendamentoCancelado);
            }else
                Console.WriteLine(Menssagens.DtConsultaInvalida);
        }
        ///<summary>
        ///Sobrescreve o método <see cref="string.ToString()"/> para a listagem da <see cref="Agenda"/>. 
        ///</summary>        
        /// <remarks>
        /// É criada uma <see cref="string"/> que recebe o cabeçalho padrão da <see cref="Agenda"/>.               
        ///<br>
        ///Após o cabeçalho são listadas as <see cref="Consultas"/> agrupadas pela <see cref="Consulta.DtConsulta"/>.
        ///</br>
        /// </remarks>
        /// <returns>
        /// Retorna uma <see cref="string"/> contendo a listagem da <see cref="Agenda"/> completa.
        /// </returns>
        public override string? ToString()
        {
            string str = "".PadRight(61, '-') + "\n" + "".PadLeft(3)
                + $"{"Data"} " + "".PadRight(3) + $"{"H.Ini"} "
                + $"{"H.Fim"} {"Tempo"} {"Nome"} {"Dt.Nasc.",26} \n"
                + "".PadRight(61, '-') + "\n";

            //Agrupando consultas por data
            var query = Consultas.GroupBy(consulta => consulta.DtConsulta);

            //Listando consultas agrupadas por data
            foreach (var result in query)
            {
                str += $"{result.Key.ToShortDateString()} ";

                foreach (Consulta c in result)
                {                    
                    Paciente? paciente = new PacienteController().PesquisaCPF(c.CPF);

                    str += $"{c.HrInicial:t} "
                     + $"{c.HrFinal:t} "
                     + $"{c.Tempo:hh\\:mm} {paciente.Nome} "
                     + $"{paciente.DtNascimento:d}\n";
                }
            }
            return str;
        }

        ///<summary>
        ///Lista a <see cref="Agenda"/> do consultório odontológico de um perído de tempo da <see langword="dtInicial"/> até a <see langword="dtFinal"/>. 
        ///</summary> 
        /// <returns>
        /// Retorna uma <see cref="string"/> contendo a listagem da <see cref="Agenda"/> por um período de tempo.
        /// </returns>
        public string AgendamentosPorPeriodo()
        {
            //Leitura da data inicial e final para listagem
            DateTime inicial = EntradaDeDados.LerDataInicial();
            DateTime final = EntradaDeDados.LerDataFinal();

            string str = $"Data inicial: {inicial:d}\n"
                       + $"Data final: {final:d}\n";

            str = "".PadRight(61, '-') + "\n" + "".PadLeft(3)
                + $"{"Data"} " + "".PadRight(3) + $"{"H.Ini"} "
                + $"{"H.Fim"} {"Tempo"} {"Nome"} {"Dt.Nasc.",26} \n"
                + "".PadRight(61, '-') + "\n";

            return PesquisaConsultasPeriodo(inicial, final).ToString();
        }

        ///<summary>
        ///Determina se a listagem da <see cref="Agenda"/> vai ser completa ou por um período.
        ///</summary> 
        /// <returns>
        /// Retorna uma <see cref="string"/> contendo a listagem da <see cref="Agenda"/>.
        /// </returns>
        public string Listagem()
        {
            char opcao = EntradaDeDados.LerOpcaoListAgenda();

            if (opcao.Equals('T'))
                return ToString();
            else
                return AgendamentosPorPeriodo();
        }
    }
}

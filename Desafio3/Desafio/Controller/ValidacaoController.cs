using Desafio.Model;
using System.Globalization;
using Desafio.Data;
using Desafio.View.Mensagens;
using System.Text.RegularExpressions;
using Desafio.Data.DAO;

namespace Desafio.Controller

{    /// <summary>
     /// Define a validadação de todos dados do <see cref="Paciente"/> e da <see cref="ConsultaController"/>.
     /// </summary>
    public class ValidacaoController
    {

        private PacienteDAO PacienteDB { get; set; }
        private ConsultaDAO ConsultaDB { get; set; }

        public ValidacaoController(PacienteDAO pcteDB, ConsultaDAO cnslt)
        {
            PacienteDB = pcteDB;
            ConsultaDB = cnslt;
        }


        /// <summary>
        /// Validação do <see cref = "Paciente.CPF" />.
        /// </ summary >
        ///< param name = "CPF">Representa o valor de um<see langword="CPF"/> que deve ser validado.</param>        
        ///<returns>
        ///<list type = "bullet" >
        ///< item >
        /// Retorna < see langword="false"/>:
        ///<list type = "bullet" >
        ///< item > Se o valor do <see langword = "CPF" /> for nulo ou vazio;</item>
        ///<item>Se o<see langword= "CPF" /> não tiver 11 dígitos;</item>
        ///<item>Se o valor de todos os dígitos do <see langword = "CPF" /> forem iguais;Ou</item>
        ///<item>Se o valor<see langword="CPF"/> for um<see langword="CPF"/> de valor inexistente.</item>
        ///</list>
        ///</item>
        ///<item>Retorna<see langword="true"/> se o valor do <see langword = "CPF" /> for um<see langword="CPF"/> de valor que existente.</item>
        ///</list>
        ///</returns>
        public bool ValidaCpf(string? CPF)
        {
            if (string.IsNullOrEmpty(CPF) && !CPF.Length.Equals(11) ||
                CPF.All(c => CPF[0].Equals(c)))
            {
                Console.WriteLine(MenssagemDeErro.CpfInvalido);
                return false;
            }

            int somaJ = 0, somaK = 0;
            int i = 10;
            foreach (char s in CPF.Substring(0, 9))
            {
                somaJ += (int)char.GetNumericValue(s) * i;
                i--;
            }

            i = 11;
            foreach (char s in CPF.Substring(0, 10))
            {
                somaK += (int)char.GetNumericValue(s) * i;
                i--;
            }

            int restoJ = somaJ % 11;
            int restoK = somaK % 11;

            bool valorJ = false;
            bool valorK = false;

            if (restoJ == 0 || restoJ == 1)
                valorJ = (int)Char.GetNumericValue(CPF[9]) == 0;
            else if (restoJ >= 2 && restoJ <= 10)
                valorJ = (int)Char.GetNumericValue(CPF[9]) == (11 - restoJ);

            if (restoK == 0 || restoK == 1)
                valorK = (int)Char.GetNumericValue(CPF[10]) == 0;
            else if (restoK >= 2 && restoK <= 10)
                valorK = (int)Char.GetNumericValue(CPF[10]) == (11 - restoK);

            if (!(valorJ || valorK))
            {
                Console.WriteLine(MenssagemDeErro.CpfInvalido);
                return false;
            }
            return true;
        }


        public bool ValidaData(TipoDeData tipo, string data)
        {
            switch(tipo) {
                case TipoDeData.DataDeNascimento: return ValidaDataNascimento(data);
                case TipoDeData.DataConsulta: return ValidaDataConsulta(data);
                case TipoDeData.DataInicialPeriodo: return ValidaDataInicial(data);
                default: {
                        Console.WriteLine(MenssagemDeErro.DtInvalida);
                        return false;
                    }
            }
        }

        public bool ValidaDataFinal(TipoDeData tipo, DateTime dtInicial, string dtFinal)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validação da <see cref="Consulta.DtConsulta"/>.
        /// </summary>
        ///<param name = "datas">Representa o valor de todas as <see langword="datas"/> na qual exitem pelo menos uma <see cref="Consulta"/> agentada.</param>        
        ///<param name = "data">Representa o valor de uma <see langword="data da consulta"/> que deve ser validada.</param>        
        ///<returns>
        ///<list type="bullet">
        ///<item>
        ///Retorna <see langword="false"/> e exibe menssagem de erro:
        ///<list type="bullet">
        ///<item>Se o valor da <see langword="data"/> não estiver no formato DD/MM/AAAA;Ou</item>
        ///<item>Se o valor da <see langword="data"/> não estiver em um período futuro;</item>        
        ///</list>
        ///</item>
        ///<item>Retorna <see langword="true"/> se não retornar <see langword="false"/>.</item>
        ///</list>
        ///</returns>
        public bool ValidaDataConsulta(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }

            DateTime dataConsulta = DateTime.Parse(data);

            if (!(dataConsulta.Date.Equals(DateTime.Now.Date) &&
                   ValidaHrConsulta(DateTime.Now.ToString("HHmm")) ||
                   dataConsulta.Date > DateTime.Now.Date))
            {
                Console.WriteLine(MenssagemDeErro.DtConsultaInvalida);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validação do formato da <see langword ="data"/>.
        /// </summary>
        ///<param name = "data">Representa o valor da <see langword="data"/> que deve estar no formato correto.</param>                
        ///<returns>
        ///<list type="bullet">
        ///<item>Retorna <see langword="false"/> e exibe menssagem de erro.</item>        
        ///<item>Retorna <see langword="true"/> e exibe menssagem de erro.</item>        
        ///</list>
        ///</returns>
        public bool ValidaDataFormato(String? data)
        {
            return DateTime.TryParse(data, out DateTime dt);
        }

        //Valida data inicial
        public bool ValidaDataInicial(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }

            return DateTime.Parse(data) < DateTime.Now;
        }

        //Valida data final
        public bool ValidaDataFinal(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }

            if (DateTime.Parse(data) >= DateTime.Now)
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFinal);
                return false;
            }

            return true;
        }

        //Valida da data de nascimento
        public bool ValidaDataNascimento(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }
            if (!(DateTime.Now.Subtract(DateTime.Parse(data)).Days / 365 >= 13))
            {
                Console.WriteLine(MenssagemDeErro.IdadeInvalida);
                return false;
            }
            return true;
        }

        //Valida da hora da consulta
        public bool ValidaHrConsulta(string? hora)
        {

            var datasIniciais = from cnslt in ConsultaDB.ListaTodos() select cnslt.DataHoraFinal;
            var datasFinais = from cnslt in ConsultaDB.ListaTodos() select cnslt.DataHoraFinal;

            IEnumerable<DateTime> datas = datasIniciais.Union(datasFinais);

            //Se o formato é válido
            if(!ValidaHoraFormato(hora))
            {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFormato);
                return false;
            }

            DateTime dtHr = DateTime.ParseExact(hora, "HHmm", new CultureInfo("pt-BR"));

            //Se existes data e hora iguais agendadas
            //if (datas.Exists(dataEhora => dataEhora.Equals(dtHr)))
            //{
            //    Console.WriteLine(MenssagemDeErro.ConsultaExistente);
            //    return false;
            //}
            foreach(DateTime dt in datas) {
                if(dt.Equals(dtHr)) {
                    Console.WriteLine(MenssagemDeErro.ConsultaExistente);
                    return false;
                }
            }

            //Se o horário é definido de 15 em 15 minutos
            if (dtHr.TimeOfDay.Minutes % 15 != 0)
            {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFormato);
                return false;
            }
            return true;
        }

        //Valida hora final
        public bool ValidaHrFinal(string? hrFinal, string? hrInicial)
        {
            //Se a Hora inicial for inválida 
            if (!ValidaHrConsulta(hrFinal))
                return false;

            DateTime horaFinal = DateTime.ParseExact(hrFinal, "HHmm", new CultureInfo("pt-BR"));
            DateTime horaInicial = DateTime.ParseExact(hrInicial, "HHmm", new CultureInfo("pt-BR"));

            //Valida a Hora final de acordo com as regras de agendamento
            if (horaFinal.TimeOfDay <= horaInicial.TimeOfDay)
            {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFinal);
                return false;
            }

            if (horaFinal.Hour == 8 && horaFinal.Minute < 15 ||
               horaFinal.Hour < 8 || horaFinal.Hour > 19)
            {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFuncionamento);
                return false;
            }
            return true;
        }

        //Valida o formato da hora
        public bool ValidaHoraFormato(string? hora)
        {
            return DateTime.TryParseExact(hora, "HHmm",
                new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime hr);
        }

        //Valida hora inicial
        public bool ValidaHrInicial(string? hora)
        {
            //Se a Hora inicial for inválida 
            if (!ValidaHrConsulta(hora))
                return false;

            DateTime hrInicial = DateTime.ParseExact(hora, "HHmm", new CultureInfo("pt-BR"));

            //Valida a Hora inicial de acordo com as regras de agendamento
            if (hrInicial.Hour < 8 || hrInicial.Hour > 18 ||
               hrInicial.Hour == 18 && hrInicial.Minute > 45)
            {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFuncionamento);
                return false;
            }
            return true;
        }

        //Valida do nome
        public bool ValidaNome(string? nome)
        {
            if (nome.Length < 5)
            {
                Console.WriteLine(MenssagemDeErro.NomeInvalido);
                return false;
            }
            return true;
        }

        //Valida opção de listagem de agenda
        public bool ValidaOpcaoListAgenda(string? opcao)
        {
            Regex rx = new Regex(@"(^[TPtp])");
            if(!rx.Match(opcao.ToUpper()).Success) {
                Console.WriteLine(MenssagemDeErro.OpcaoInvalida);
                return false;
            }

            return true;
        }

        public bool PacienteExiste(long cpf)
        {
            Paciente p = PacienteDB.ListaPorCPF(cpf);
            if (p == null) return false;

            return true;
        }
    }
}

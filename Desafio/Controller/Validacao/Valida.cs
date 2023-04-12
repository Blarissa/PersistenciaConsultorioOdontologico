using Desafio.Model;
using System.Globalization;
using Desafio.View.Mensagens;

namespace Desafio.Controller.Validacao
{
    
    /// <summary>
    /// Define a validadação de todos dados do <see cref="Paciente"/> e da <see cref="ConsultaController"/>.
    /// </summary>
    public class Valida : IValida
    {       
        /// <summary>
        /// Validação do <see cref = "Paciente.CPF" />.
        /// </summary >
        ///<param name = "CPF">Representa o valor de um<see langword="CPF"/> que deve ser validado.</param>        
        ///<returns>
        ///<list type = "bullet" >
        ///<item >
        /// Retorna <see langword="false"/>:
        ///<list type = "bullet" >
        ///<item > Se o valor do <see langword = "CPF" /> for nulo ou vazio;</item>
        ///<item>Se o<see langword= "CPF" /> não tiver 11 dígitos;</item>
        ///<item>Se o valor de todos os dígitos do <see langword = "CPF" /> forem iguais;Ou</item>
        ///<item>Se o valor<see langword="CPF"/> for um<see langword="CPF"/> de valor inexistente.</item>
        ///</list>
        ///</item>
        ///<item>Retorna<see langword="true"/> se o valor do <see langword = "CPF" /> for um<see langword="CPF"/> de valor que existente.</item>
        ///</list>
        ///</returns>
        
        public bool CPF(string? CPF)
        {
            if (ValidaFormato.CPF(CPF) &&
                ValidaRegras.CPF(CPF))       
                return true;

            Console.WriteLine(MensagemDeErro.CpfInvalido);
            return false;
        }

        public bool Nome(string? nome)
        {
            return ValidaFormato.Nome(nome);                          
        }

        public bool Data(ETipoDeDataHora tipo, string data)
        {
            if(ValidaFormato.Data(data))
                return ValidaPorTipoDataHora(tipo, data.ToDateTime());

            return false;
        }

        public bool Data(ETipoDeDataHora tipo, DateTime dataInicio, string dataFim)
        {
            if (ValidaFormato.Data(dataFim))
                return ValidaPorTipoDataHora(tipo, dataInicio, dataFim.ToDateTime());
            
            return false;
        }

        public bool DataHora(ETipoDeDataHora tipo, string dataHora)
        {
            if (ValidaFormato.DataHora(dataHora))
            {
                var ptBR = new CultureInfo("pt-BR");
                var dtHr = DateTime.ParseExact(dataHora, 
                    "dd/MM/yyyy HHmm", ptBR);

                return ValidaPorTipoDataHora(tipo, dtHr);
            }

            return false;
        }

        public bool DataHora(ETipoDeDataHora tipo, DateTime dataHoraInicio, string dataHoraFim)
        {
            if (ValidaFormato.DataHora(dataHoraFim))
            {
                var ptBR = new CultureInfo("pt-BR");
                var dtHr = DateTime.ParseExact(dataHoraFim,
                    "dd/MM/yyyy HHmm", ptBR);

                return ValidaPorTipoDataHora(tipo, dataHoraInicio, dtHr);
            }

            return false;
        }

        private bool ValidaPorTipoDataHora(ETipoDeDataHora tipo, DateTime dataHora)
        {           
            switch (tipo)
            {
                case ETipoDeDataHora.DataDeNascimento:
                    return ValidaRegras.DataNascimento(dataHora);

                case ETipoDeDataHora.DataConsulta:
                    return ValidaRegras.DataConsulta(dataHora);

                case ETipoDeDataHora.HoraInicial:
                    return ValidaRegras.HoraInicialConsulta(dataHora);

                default:
                    Console.WriteLine(MensagemDeErro.DtInvalida);
                    return false;
            }            
        }

        private bool ValidaPorTipoDataHora(ETipoDeDataHora tipo, DateTime dataHoraInicial, 
            DateTime dataHoraFinal)
        {
            switch (tipo)
            {
                case ETipoDeDataHora.DataFinalPeriodo:
                    return ValidaRegras.DataFinal(dataHoraInicial, dataHoraFinal);

                case ETipoDeDataHora.HoraFinal: 
                    return ValidaRegras.HoraFinalConsulta(dataHoraInicial, dataHoraFinal);

                default:
                    Console.WriteLine(MensagemDeErro.DtInvalida);
                    return false;
            }      
        }

        public bool OpcaoDeListagem(string opcao)
        {
            return ValidaFormato.OpcaoDeListagem(opcao);
        }
    }
}

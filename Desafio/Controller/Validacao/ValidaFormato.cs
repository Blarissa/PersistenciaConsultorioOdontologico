using Desafio.View.Mensagens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Controller.Validacao
{
    public class ValidaFormato 
    {
        public static bool CPF(string? cpf)
        {
            return !string.IsNullOrEmpty(cpf) &&
                   cpf.All(c => char.IsDigit(c)) &&
                   cpf.Length.Equals(11) &&
                   cpf.Any(c => !cpf[0].Equals(c));
        }

        public static bool Data(string? data)
        {
            var ptBR = new CultureInfo("pt-BR");
      
            if (DateTime.TryParseExact(data, "d", 
                ptBR, DateTimeStyles.None, out DateTime dt))
                return true;

            Console.WriteLine(MensagemDeErro.DtInvalidaFormato);
            return false;
        }

        public static bool DataHora(string? dataHora)
        {
            var ptBR = new CultureInfo("pt-BR");

            if (DateTime.TryParseExact(dataHora,
                "dd/MM/yyyy HHmm", ptBR, 
                DateTimeStyles.None, out DateTime dt))
                return true;

            Console.WriteLine(MensagemDeErro.DtInvalidaFormato);
            return false;
        }

        public static bool Nome(string nome)
        {
            if(!string.IsNullOrEmpty(nome) && nome.Length >= 5)
                return true;

            Console.WriteLine(MensagemDeErro.NomeInvalido);
            return false;
        }

        public static bool OpcaoDeListagem(string opcao)
        {                               
            if(opcao.Equals('T') || opcao.Equals('P'))
                return true;

            Console.WriteLine(MensagemDeErro.OpcaoInvalida);
            return false;
        }
    }
}

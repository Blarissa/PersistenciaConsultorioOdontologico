using System.Globalization;

namespace Desafio1
{
    internal class Valida
    {        
        //Valida CPF
        public static bool ValidaCpf(string? CPF)
        {            
            if (string.IsNullOrEmpty(CPF) && !CPF.Length.Equals(11) ||
                CPF.All(c => CPF[0] == c)){
                Console.WriteLine(Menssagens.CpfIvalido);
                return false;
            }
                
            int somaJ = 0, somaK = 0;
            int a = 0; 
                
            for (int i = 10; i >= 2; i--, a++)
                somaJ += (int)Char.GetNumericValue(CPF[a]) * i;

            a = 0;
            for (int i = 11; i >= 2; i--, a++)
                somaK += (int)Char.GetNumericValue(CPF[a]) * i;
                
            int restoJ = somaJ % 11;
            int restoK = somaK % 11;
                
            bool J = false;
            bool K = false;

            if (restoJ == 0 || restoJ == 1)
                J = (int)Char.GetNumericValue(CPF[9]) == 0;
            else if (restoJ >= 2 && restoJ <= 10)
                J = (int)Char.GetNumericValue(CPF[9]) == (11 - restoJ);

            if (restoK == 0 || restoK == 1)
                K = (int)Char.GetNumericValue(CPF[10]) == 0;
            else if (restoK >= 2 && restoK <= 10)
                K = (int)Char.GetNumericValue(CPF[10]) == (11 - restoK);               
               
            if(!(J || K)){
                Console.WriteLine(Menssagens.CpfIvalido);
                return false;
            }
            return true;           
        }
        
        //Valida a data da consulta
        public static bool ValidaDataConsulta(List<DateTime> datas, string? data)
        {
            if (!ValidaDataFormato(data)){
                Console.WriteLine(Menssagens.DtInvalidaFormato);
                return false;
            }

            DateTime dataConsulta = DateTime.Parse(data);

            if(!(dataConsulta.Date.Equals(DateTime.Now.Date) &&
                   ValidaHrConsulta(datas, DateTime.Now.ToString("HHmm")) ||
                   dataConsulta.Date > DateTime.Now.Date)){
                Console.WriteLine(Menssagens.DtConsultaInvalida);
                return false;
            }
           return true;
        }
                
        //Valida do formato de data
        public static bool ValidaDataFormato(String? data)
        {
            return DateTime.TryParse(data, out DateTime dt);
        }

        //Valida data inicial
        public static bool ValidaDataInicial(string? data)
        {
            if (!ValidaDataFormato(data)){
                Console.WriteLine(Menssagens.DtInvalidaFormato);
                return false;
            }

            return DateTime.Parse(data) < DateTime.Now;         
        }
        
        //Valida data final
        public static bool ValidaDataFinal(string? data)
        {
            if (!ValidaDataFormato(data)){
                Console.WriteLine(Menssagens.DtInvalidaFormato);
                return false;
            }

            if (DateTime.Parse(data) >= DateTime.Now){
                Console.WriteLine(Menssagens.DtFinalInvalida);
                return false;
            }

            return true;
        }

        //Valida da data de nascimento
        public static bool ValidaDataNascimento(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(Menssagens.DtInvalidaFormato);
                return false;
            }
            if(!(DateTime.Now.Subtract(DateTime.Parse(data)).Days / 365 >= 13))
            {
                Console.WriteLine(Menssagens.IdadeInvalida);
                return false;
            }           
            return true;
        }

        //Valida da hora da consulta
        public static bool ValidaHrConsulta(List<DateTime> datas, string? hora)
        {   
            //Se o formato é válido
            if (!ValidaHoraFormato(hora))
            {
                Console.WriteLine(Menssagens.DtInvalidaFormato);                
                return false;
            } 
            
            DateTime dtHr = DateTime.ParseExact(hora, "HHmm", new CultureInfo("pt-BR"));
            
            //Se existes data e hora iguais agendadas
            if (datas.Exists(dataEhora => dataEhora.Equals(dtHr)))
            {
                Console.WriteLine(Menssagens.ConsultExistente);
                return false;
            }

            //Se o horário é definido de 15 em 15 minutos
            if(dtHr.TimeOfDay.Minutes % 15 != 0)
            {
                Console.WriteLine(Menssagens.HrInvalida);
                return false;
            }
            return true;
        }

        //Valida hora final
        public static bool ValidaHrFinal(List<DateTime> datas, string? hrFinal, string? hrInicial)
        {
            //Se a Hora inicial for inválida 
            if (!ValidaHrConsulta(datas, hrFinal))
                return false;

            DateTime horaFinal = DateTime.ParseExact(hrFinal, "HHmm", new CultureInfo("pt-BR"));
            DateTime horaInicial = DateTime.ParseExact(hrInicial, "HHmm", new CultureInfo("pt-BR"));

            //Valida a Hora final de acordo com as regras de agendamento
            if (horaFinal.TimeOfDay <= horaInicial.TimeOfDay){
                Console.WriteLine(Menssagens.HrFinalInvalida);
                return false;
            }

            if (horaFinal.Hour == 8 && horaFinal.Minute < 15 ||
               horaFinal.Hour < 8 || horaFinal.Hour > 19){
                Console.WriteLine(Menssagens.HrInvalidaFuncionamento);
                return false;
            }
            return true;
        }

        //Valida o formato da hora
        public static bool ValidaHoraFormato(string? hora)
        {   
            return DateTime.TryParseExact(hora, "HHmm",
                new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime hr);
        }

        //Valida hora inicial
        public static bool ValidaHrInicial(List<DateTime> datas, string? hora)
        {
            //Se a Hora inicial for inválida 
            if (!ValidaHrConsulta(datas,hora))
                return false;
            
            DateTime hrInicial = DateTime.ParseExact(hora, "HHmm", new CultureInfo("pt-BR"));

            //Valida a Hora inicial de acordo com as regras de agendamento
            if(hrInicial.Hour < 8 || hrInicial.Hour > 18 ||
               hrInicial.Hour == 18 && hrInicial.Minute > 45){
                Console.WriteLine(Menssagens.HrInvalidaFuncionamento);
                return false;
            }
            return true;
        }
                
        //Valida do nome
        public static bool ValidaNome(string? nome)
        {
            if(nome.Length < 5){
                Console.WriteLine(Menssagens.NomeIvalido);
                return false;
            }
            return true;
        }

        //Valida opção de listagem de agenda
        public static bool ValidaOpcaoListAgenda(char? opcao)
        {
            return opcao.HasValue && (opcao.Equals('T') || opcao.Equals('P'));
        }
    }
}

using Desafio.View.Mensagens;

namespace Desafio.Controller.Validacao
{
    public class ValidaRegras
    {
        public static bool CPF(string cpf)
        {
            int somaJ = Soma(cpf, 10);
            int somaK = Soma(cpf, 11);

            int restoJ = somaJ % 11;
            int restoK = somaK % 11;

            bool valorJ = Valor(cpf, restoJ, 9);
            bool valorK = Valor(cpf, restoK, 10);

            return valorJ && valorK;
        }

        public static bool DataNascimento(DateTime data)
        {
            int idade = DateTime.Now.Subtract(data).Days / 365;

            if (idade >= 13)
                return true;

            Console.WriteLine(MensagemDeErro.IdadeInvalida);
            return false;
        }

        public static bool DataConsulta(DateTime dataHora)
        {
            return DataNoFuturo(dataHora);                      
        }

        public static bool DataFinal(DateTime dataInicial, DateTime dataFinal)
        {
            if(dataFinal > dataInicial)
                return true;

            Console.WriteLine(MensagemDeErro.DtInvalidaFinal);
            return false;
        }

        public static bool HoraInicialConsulta(DateTime dataHora)
        {
            var hora = dataHora.TimeOfDay;

            return HoraNoFuturo(hora) &&
                   HorarioFuncionamento(hora) &&
                   Hora15em15(hora);
        }

        public static bool HoraFinalConsulta(DateTime dataHoraInicial, 
            DateTime dataHoraFinal)
        {
            var horaInicial = dataHoraInicial.TimeOfDay;
            var horaFinal = dataHoraFinal.TimeOfDay;

            return HoraFinalMaiorInicial(horaInicial, horaFinal) && 
                   HoraNoFuturo(horaFinal) &&
                   HorarioFuncionamento(horaFinal) &&
                   Hora15em15(horaFinal);
        }
        
        //Se a data estiver no futuro 
        private static bool DataNoFuturo(DateTime dataHora)
        {
            var data = dataHora.Date;

            if (data > DateTime.Now)
                return true;

            Console.WriteLine(MensagemDeErro.ConsultaInvalida);
            return false;            
        }

        //Se a hora final for maior que a hora inicial
        private static bool HoraFinalMaiorInicial(TimeSpan horaInicial, TimeSpan horaFinal)
        {
            if (horaInicial > horaFinal)
            {
                Console.WriteLine(MensagemDeErro.HrInvalidaFinal);
                return false;
            }

            return true;
        }

        //Se a hora estiver no futuro 
        private static bool HoraNoFuturo(TimeSpan hora) 
        {
            if(hora < DateTime.Now.TimeOfDay)
            {
                Console.WriteLine(MensagemDeErro.ConsultaInvalida);
                return false;
            }

            return true;
        }

        //Se estiver no horário de funcionamento
        private static bool HorarioFuncionamento(TimeSpan hora) 
        {
            var inicioExpediente = new TimeSpan(8, 0, 0);
            var fimExpediente = new TimeSpan(19, 0, 0);

            if (hora < inicioExpediente ||
                hora > fimExpediente)
            {
                Console.WriteLine(MensagemDeErro.HrInvalidaFuncionamento);
                return false;
            }

            return true;
        }

        //Se o horário é definido de 15 em 15 minutos
        private static bool Hora15em15(TimeSpan hora) 
        {
            if (hora.Minutes % 15 != 0)
            {
                Console.WriteLine(MensagemDeErro.HrInvalidaMultiplos);
                return false;
            }

            return true;
        }

        private static bool Valor(string cpf, int restoJ, int i)
        {
            bool valor = true;

            if (restoJ == 0 || restoJ == 1)
                valor = (int)Char.GetNumericValue(cpf[i]) == 0;

            else if (restoJ >= 2 && restoJ <= 10)
                valor = (int)Char.GetNumericValue(cpf[i]) == (11 - restoJ);

            return valor;
        }

        private static int Soma(string cpf, int i)
        {
            int somaJ = 0;

            foreach (char s in cpf.Substring(0, i - 1))
            {
                somaJ += (int)char.GetNumericValue(s) * i;
                i--;
            }

            return somaJ;
        }
    }
}

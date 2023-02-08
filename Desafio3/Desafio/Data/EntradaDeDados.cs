using Desafio.Controller;
using Desafio.View.Mensagens;
using Desafio.Model;
using System.Globalization;
using Desafio.Data.DAO;

namespace Desafio.Data
{
    public class EntradaDeDados
    {
        private IRecebimentoDeDados Input { get; set; }
        private ValidacaoController Validador { get; set; }

        public EntradaDeDados(IRecebimentoDeDados input, ValidacaoController val)
        {
            Input = input;
            Validador = val;
        }

        //Ler CPF
        public long RetornaCPF()
        {
            string CPF;

            //CPF inválido ler novamente
            do {
                CPF = Input.LerCpf();
            } while(!Validador.ValidaCpf(CPF));

            return long.Parse(CPF);
        }

        public long RetornaCPFseExistir()
        {
            string CPF;

            //CPF inválido ler novamente
            do {
                CPF = Input.LerCpf();
                if(!Validador.ValidaCpf(CPF)) continue;
            } while(!Validador.PacienteExiste(long.Parse(CPF)));

            return long.Parse(CPF);
        }

        //Ler Nome
        public string RetornaNome()
        {
            var nome = Input.LerNome();

            //nome inválido ler dados novamente
            if(!Validador.ValidaNome(nome))
                return Input.LerNome();

            return nome;
        }



        public DateTime RetornaData(TipoDeData tipo)
        {
            string data;

            do {
                data = Input.LerData(tipo);
            } while(!Validador.ValidaData(tipo, data));

            return DateTime.Parse(data);

        }

        public DateTime RetornaDataFinal(DateTime dtInicial)
        {
            string dtFinal;

            do {
                dtFinal = Input.LerData(TipoDeData.DataFinalPeriodo);
            } while(!Validador.ValidaDataFinal(TipoDeData.DataFinalPeriodo, dtInicial, dtFinal));

            return DateTime.Parse(dtFinal);
        }

        public DateTime RetornaHoraInicial(TipoDeHora tipo, DateTime data)
        {
            string hora;

            do {
                hora = Input.LerHora(tipo);
            } while(!Validador.ValidaHoraInicial(TipoDeHora.HoraInicial, data, hora));

            return data + DateTime.ParseExact(hora, "HH:mm", new CultureInfo("pt-BR")).TimeOfDay;
        }

        public DateTime RetornaHoraFinal(DateTime data, DateTime horaInicial)
        {
            string hora;

            do {
                hora = Input.LerHora(TipoDeHora.HoraFinal);
            } while(!Validador.ValidaHoraFinal(data, horaInicial, hora));

            return data + DateTime.ParseExact(hora, "HH:mm", new CultureInfo("pt-BR")).TimeOfDay;
        }

        //Ler 
        public char RetornarOpcaoListAgenda()
        {
            string opcao = Input.LerOpcaoDeListagemDaAgenda();

            if(!Validador.ValidaOpcaoListAgenda(opcao)) {
                Console.WriteLine(MenssagemDeErro.OpcaoInvalida);
                return RetornarOpcaoListAgenda();
            }

            return char.Parse(opcao);
        }
    }
}

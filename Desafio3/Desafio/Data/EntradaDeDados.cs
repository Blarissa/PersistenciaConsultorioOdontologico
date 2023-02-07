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

        public EntradaDeDados(IRecebimentoDeDados input, PacienteDAO pctDB, ConsultaDAO cnsltDB )
        {
            Input = input;
            Validador = new ValidacaoController(pctDB, cnsltDB);
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

        //Ler Nome
        public string RetornaNome()
        {
            var nome = Input.LerNome();

            //nome inválido ler dados novamente
            if (!Validador.ValidaNome(nome))
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

        //Ler 
        public char LerOpcaoListAgenda()
        {
            string opcao = Input.LerOpcaoDeListagemDaAgenda();

            if (!Validador.ValidaOpcaoListAgenda(opcao))
            {
                Console.WriteLine(MenssagemDeErro.OpcaoInvalida);
                return LerOpcaoListAgenda();
            }

            return opcao[0];
        }
    }
}

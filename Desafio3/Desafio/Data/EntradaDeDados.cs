using Desafio.Controller;
using Desafio.View.Mensagens;
using Desafio.Model;
using System.Globalization;

namespace Desafio.Data
{
    public class EntradaDeDados
    {
        private IRecebimentoDeDados Input { get; set; }

        public EntradaDeDados(IRecebimentoDeDados input)
        {
            Input = input;
        }

        //Ler CPF
        public long RetornaCPF()
        {
            string CPF;

            //CPF inválido ler novamente
            do {
                CPF = Input.LerCpf();
            } while(!ValidacaoController.ValidaCpf(CPF));

            return long.Parse(CPF);
        }

        //Ler Nome
        public string RetornaNome()
        {
            var nome = Input.LerNome();

            //nome inválido ler dados novamente
            if (!ValidacaoController.ValidaNome(nome))
                return Input.LerNome();

            return nome;
        }


        
        public DateTime RetornaData(TipoDeData tipo)
        {
            string data = "";

            do {
                data = Input.LerData(tipo);
            } while(!ValidacaoController.ValidaData(tipo, data));
            
        }

        public DateTime RetornaDataFinal(DateTime dtInicial)
        {
            string dtFinal = "";

            do {
                dtFinal = Input.LerData(TipoDeData.DataFinalPeriodo);
            } while(!ValidacaoController.ValidaDataFinal(TipoDeData.DataFinalPeriodo, dtInicial, dtFinal));
        }

        //Ler 
        public char LerOpcaoListAgenda()
        {
            string opcao = Input.LerOpcaoDeListagemDaAgenda();

            if (!ValidacaoController.ValidaOpcaoListAgenda(opcao))
            {
                Console.WriteLine(MenssagemDeErro.OpcaoInvalida);
                return LerOpcaoListAgenda();
            }

            return opcao;
        }
    }
}

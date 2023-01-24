using Desafio.Desafio.Controllers;
using System.Globalization;

namespace Desafio.Desafio.View
{
    public class EntradaDeDados
    {
        //Ler CPF
        public static long LerCPF()
        {
            Console.WriteLine("CPF:");
            var CPF = Console.ReadLine();

            //CPF inválido ler novamente
            if (!Valida.ValidaCpf(CPF))
                return LerCPF();            

            return long.Parse(CPF);
        }

        //Ler Nome
        public static string LerNome()
        {
            Console.WriteLine("Nome:");
            var nome = Console.ReadLine();

            //nome inválido ler dados novamente
            if (!Valida.ValidaNome(nome))
                return LerNome();

            return nome;
        }

        //Ler Data de nascimento
        public static DateTime LerDtNascimento()
        {
            Console.WriteLine("Data de nascimento:");
            var dtNasc = Console.ReadLine();

            //Data de nascimento inválido ler dados novamente
            if (!Valida.ValidaDataNascimento(dtNasc))
                return LerDtNascimento();

            return DateTime.Parse(dtNasc);
        }

        //Ler Data da consulta
        public static DateTime LerDtConsulta()
        {
            Console.WriteLine("Data da consulta:");
            var data = Console.ReadLine();

            var datas = new Agenda().Agendamentos;

            //Data inválida ler dados novamente
            if (!Valida.ValidaDataConsulta(datas, data))
                return LerDtConsulta();
            
            return DateTime.Parse(data);
        }

        //Ler Hora inicial da consulta
        public static DateTime LerHrInicial()
        {
            Console.WriteLine("Hora inicial:");
            var hrInicial = Console.ReadLine();

            //Hora inicial inválida ler dados novamente
            if (!Valida.ValidaHrInicial(new Agenda().Agendamentos, hrInicial))
                return LerHrInicial();
            
            return DateTime.ParseExact(hrInicial, "HHmm", new CultureInfo("pt-BR"));
        }

        //Ler Hora final da consulta
        public static DateTime LerHrFinal(string hrInicial)
        {
            Console.WriteLine("Hora final:");
            var hrFinal = Console.ReadLine();

            //Hora Final inválida ler dados novamente
            if (!Valida.ValidaHrFinal(new Agenda().Agendamentos, hrFinal, hrInicial))
                return LerHrFinal(hrInicial);

            return DateTime.ParseExact(hrFinal, "HHmm", new CultureInfo("pt-BR"));
        }

        //Ler período para listar agenda
        public static DateTime LerDataInicial() {
            Console.WriteLine("Data inicial: ");
            var data = Console.ReadLine();
            
            if (Valida.ValidaDataInicial(data)){
                Console.WriteLine(Menssagens.DtInicialInvalida);
                return LerDataInicial();
            }

            return DateTime.Parse(data);
        }

        //Ler período para listar agenda
        public static DateTime LerDataFinal()
        {
            Console.WriteLine("Data final: ");
            var data = Console.ReadLine();

            if (Valida.ValidaDataFinal(data))
            {
                Console.WriteLine(Menssagens.DtFinalInvalida);
                return LerDataFinal();
            }

            return DateTime.Parse(data);
        }

        //Ler 
        public static Char LerOpcaoListAgenda()
        {
            Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
            char opcao = char.Parse(Console.ReadLine().ToUpper());

            if (!Valida.ValidaOpcaoListAgenda(opcao))
            {
                Console.WriteLine(Menssagens.OpcaoInvalida);
                return LerOpcaoListAgenda();
            }                

            return opcao;
        }
    }
}

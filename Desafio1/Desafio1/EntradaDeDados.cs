using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class EntradaDeDados
    {
        public static long LerCPF()
        {
            Console.WriteLine("CPF:");
            var CPF = Console.ReadLine();

            //CPF inválido ler novamente
            if (!Valida.ValidaCpf(CPF))
                LerCPF();

            //Verifica se já existe um CPF igual
            if (new PacienteController().PacienteExiste(long.Parse(CPF)))
            {
                Console.WriteLine(Menssagens.CpfExistente);
                LerCPF();
            }

            return long.Parse(CPF);
        }
        
        public static string LerNome()
        {
            Console.WriteLine("Nome:");
            var nome = Console.ReadLine();

            //nome inválido ler dados novamente
            if (!Valida.ValidaNome(nome))
                LerNome();

            return nome;
        }

        public static DateTime LerDtNascimento()
        {
            Console.WriteLine("Data de nascimento:");
            var dtNasc = Console.ReadLine();

            //Data de nascimento inválido ler dados novamente
            if (!Valida.ValidaDataNascimento(dtNasc))
                LerDtNascimento();

            return DateTime.Parse(dtNasc);
        }

        public static DateTime LerDtConsulta()
        {
            Console.WriteLine("Data da consulta:");
            var data = Console.ReadLine();

            //Data inválida ler dados novamente
            if (!Valida.ValidaDataConsulta(new Agenda().Agendamentos, data))
                LerDtConsulta();
            
            return DateTime.Parse(data);
        }

        public static DateTime LerHrInicial()
        {
            Console.WriteLine("Hora inicial:");
            var hrInicial = Console.ReadLine();

            //Hora inicial inválida ler dados novamente
            if (!Valida.ValidaHrInicial(new Agenda().Agendamentos, hrInicial))
                LerHrInicial();
            
            return DateTime.ParseExact(hrInicial, "HHmm", new CultureInfo("pt-BR"));
        }

        public static DateTime LerHrFinal(string hrInicial)
        {
            Console.WriteLine("Hora final:");
            var hrFinal = Console.ReadLine();

            //Hora Final inválida ler dados novamente
            if (!Valida.ValidaHrFinal(new Agenda().Agendamentos, hrFinal, hrInicial))
                LerHrFinal(hrInicial);

            return DateTime.ParseExact(hrFinal, "HHmm", new CultureInfo("pt-BR"));
        }
    }
}

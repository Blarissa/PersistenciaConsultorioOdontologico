using Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DadosComConsole
{
    internal class EntradaDeConsole : IRecebimentoDeDados
    {
        public string LerCpf()
        {
            Console.WriteLine("CPF:");
            var CPF = Console.ReadLine() ?? "";

            return CPF;
        }
        public string LerData(TipoDeData tipo)
        {
            switch(tipo) {
                case TipoDeData.DataDeNascimento: Console.WriteLine("Data de nascimento:"); break;
                case TipoDeData.DataInicialPeriodo: Console.WriteLine("Data inicial:"); break;
                case TipoDeData.DataFinalPeriodo: Console.WriteLine("Data final:"); break;
                case TipoDeData.DataConsulta: Console.WriteLine("Data da consulta:"); break;
            }

            var data = Console.ReadLine() ?? "";
            return data;
        }

        public string LerHora(TipoDeHora tipo)
        {
            switch(tipo) {
                case TipoDeHora.HoraInicial: Console.WriteLine("Hora inicial:"); break;
                case TipoDeHora.HoraFinal: Console.WriteLine("Hora final:"); break;
            }

            var hora = Console.ReadLine() ?? "";
            return hora;
        }

        public string LerNome()
        {
            Console.WriteLine("Nome:");
            var nome = Console.ReadLine() ?? "";
            return nome;
        }

        public string LerOpcaoDeListagemDaAgenda()
        {
            Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
            var opcao = Console.ReadLine() ?? "";
            return opcao.ToUpper();
        }
    }
}
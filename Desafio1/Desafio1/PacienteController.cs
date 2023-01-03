using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Desafio1
{
    internal class PacienteController
    {
        List<Paciente> Pacientes = new List<Paciente>();

        public PacienteController() {
        }

        //Adionando paciente
        public void Adiciona() {
            Paciente paciente = new (EntradaDeDados.LerCPF(),
                                     EntradaDeDados.LerNome(),
                                     EntradaDeDados.LerDtNascimento());

            Pacientes.Add(paciente);
            Console.WriteLine(PacientesOrdemNome());
            Console.WriteLine(Menssagens.PacienteCadastrado);
        }       
        
        //Retorna o paciente de determinado CPF 
        public Paciente? PesquisaCPF(long CPF)
        {   
            if(PacienteExiste(CPF))           
                return Pacientes.Find(paciente => paciente.CPF.Equals(CPF));

            return null;                       
        }

        //Retorna se o paciente existe
        public bool PacienteExiste(long CPF)
        {
            return Pacientes.Exists(paciente => paciente.CPF.Equals(CPF));
        }        

        //Removendo paciente
        public void Remove()
        {
            long CPF = EntradaDeDados.LerCPF();
            //Se não encontrar o paciente na lista imprime a mensagem de erro
            while (!PacienteExiste(CPF)){
                Console.WriteLine(Menssagens.PacienteInixistente);
                CPF = EntradaDeDados.LerCPF();
            }

            Pacientes.Remove(PesquisaCPF(CPF));
            Console.WriteLine(Menssagens.PacienteExcluido);          
        }

        public void Adddnskl()
        {
            Pacientes.Add(new Paciente(
                long.Parse("05956347376"),
                "Larissa dos Santos Brasil",
                DateTime.Parse("21/09/2001")));

            Pacientes.Add(new Paciente(
                88107612353,
                "Jordânia Sampaio Santos",
                DateTime.Parse("01/04/1980")));

            Pacientes.Add(new Paciente(
                47361883320,
                "Mauro Cesar Brasil Silva",
                DateTime.Parse("09/12/1970")));

            
        }
        
        public override string? ToString()
        {
            string str = ("").PadRight(60, '-') + "\n"
                       + $"{"CPF",-11} {"Nome",-33} {"Dt.Nasc."} {"Idade"}\n"
                       + ("").PadRight(60, '-') + "\n";

            Pacientes.ForEach(p =>
                str += $"{p.CPF,-11} " +
                       $"{p.Nome,-33} " +
                       $"{p.DtNascimento.ToShortDateString()} " +
                       $"{p.Idade}\n");
                //+$"{"",-12}{str1}\n"
                //+ $"{"",-12}{str2}\n");

            return str;
        }

        //Listar pacientes(ordenado por nome)
        public string? PacientesOrdemNome()
        {            
            Pacientes = Pacientes.OrderBy(p => p.Nome).ToList();                

            return ToString();
        }

        //Listar pacientes(ordenado por CPF)
        public string? PacientesOrdemCPF()
        {
            Pacientes = Pacientes.OrderBy(p => p.CPF).ToList();
            return ToString();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Desafio1
{
    internal class PacienteController
    {
        List<Paciente> Pacientes = new();
        
        //Adionando paciente
        public void Adiciona() {
            Paciente paciente = new (EntradaDeDados.LerCPF(),
                                     EntradaDeDados.LerNome(),
                                     EntradaDeDados.LerDtNascimento());

            Pacientes.Add(paciente);
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

        /*
        //Listar pacientes(ordenado por CPF)
        public String PacientesOrdemNome()
        {            
            return "";
        }

        //Listar pacientes(ordenado por nome)
        public String PacientesOrdemCPF()
        {
            return "";
        }
        */
    }
}

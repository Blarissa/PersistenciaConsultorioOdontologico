using Desafio.Desafio.Models;
using Desafio.Desafio.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Dasafio.Dados
{
    internal class PacienteDAO
    {
        private List<Paciente> Pacientes { get; set; }

        public PacienteDAO() { 
            Pacientes = new List<Paciente>();
        }

       
        /// <summary>
        /// Busca nos dados armazenados pacientes com o cpf informado
        /// </summary>
        /// <param name="cpf">Cpf a ser buscado</param>
        /// <returns>
        /// Retorna o primeiro paciente com o cpf encontrado
        /// </returns>
        public Paciente? PacientesPorCpf(long cpf)
        {
            var query = from pcte in Pacientes where pcte.CPF == cpf select pcte;

            return query.GetEnumerator().Current;
        }

        /// <returns>
        /// Retorna uma lista com todos os pacientes armazenados no storage
        /// </returns>
        public List<Paciente> TodosPacientes()
        {
            return Pacientes;
        }


        //Adicionar
        public void AdicionarPaciente(long cpf, string nome, DateTime dtNasc)
        {
            Pacientes.Add(new(cpf, nome, dtNasc));
            Console.WriteLine(Menssagens.PacienteCadastrado);
        }

        //Remover
        public void RemoverPaciente(long CPF)
        {
            Paciente? paraRemover = PacientesPorCpf(CPF);
            if(paraRemover != null) {
                Pacientes.Remove(paraRemover);
            }
        }

        //Atualizar

    }
}

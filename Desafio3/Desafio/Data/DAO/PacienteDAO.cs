using Desafio.Model;
using Desafio.View;
using Desafio.View.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DAO
{ 

    internal class PacienteDAO : IComando<Paciente>
    {
        ConsultorioContexto contexto;

        public PacienteDAO(ConsultorioContexto contexto) { 
            this.contexto = contexto;
        }      

        public void Adicionar(Paciente paciente)
        {
            contexto.Pacientes.Add(paciente);
            contexto.SaveChanges();
        }

        public void Remover(Paciente paciente)
        {
            contexto.Pacientes.Remove(paciente);
            contexto.SaveChanges();
        }

        public IList<Paciente> ListaTodos()
        {
            return contexto.Pacientes.ToList();
        }

        public Paciente? ListaPorCPF(long cpf)
        {
            return contexto.Pacientes.Find(cpf);
        }

    }
}

using Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DAO
{
    public class ValidacaoDAO
    {
        private ConsultorioContexto DbCtxt { get; set; }
        public ValidacaoDAO(ConsultorioContexto consultorioCtxt) {
            DbCtxt = consultorioCtxt;
        }

        public Paciente ListarPacientePorCPF(long CPF)
        {
            return DbCtxt.Pacientes.Find(CPF);
        }

        public int QtdConsultasConflituosasHoraInicial(DateTime horaInicial)
        {
            return (from apt in DbCtxt.Consultas
             where apt.DataHoraFinal.CompareTo(horaInicial) > 0 && apt.DataHoraInicial.CompareTo(horaInicial) <= 0
             select apt).Count();
        }

        public int QtdConsultasConflituosasHoraFinal(DateTime horaFinal)
        {
            return (from apt in DbCtxt.Consultas
                    where apt.DataHoraFinal.CompareTo(horaFinal) >= 0 && apt.DataHoraInicial.CompareTo(horaFinal) < 0
                    select apt).Count();
        }

    }
}

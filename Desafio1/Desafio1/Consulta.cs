using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class Consulta
    {
        public long CPF { get; private set; }
        public DateTime DtConsulta { get; private set; }
        public DateTime HrInicial { get; private set; }
        public DateTime HrFinal { get; private set; }
        public TimeSpan Tempo { get => this.HrFinal - this.HrInicial; }
        
        public Consulta(){}

        public Consulta(long CPF, DateTime DtConsulta, DateTime HrInicial, DateTime HrFinal)
        {
            this.CPF = CPF;
            this.DtConsulta = DtConsulta;
            this.HrInicial = HrInicial;
            this.HrFinal = HrFinal;
        }
    }
}

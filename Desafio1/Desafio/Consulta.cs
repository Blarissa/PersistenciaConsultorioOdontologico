namespace Desafio1
{
    internal class Consulta
    {
        public long CPF { get; private set; }
        public DateTime DtConsulta { get; private set; }
        public DateTime HrInicial { get; private set; }
        public DateTime HrFinal { get; private set; }
        public TimeSpan Tempo { get => HrFinal - HrInicial; }

        public Consulta() { }

        public Consulta(long CPF, DateTime DtConsulta, DateTime HrInicial, DateTime HrFinal)
        {
            this.CPF = CPF;
            this.DtConsulta = DtConsulta;
            this.HrInicial = HrInicial;
            this.HrFinal = HrFinal;
        }
    }
}

namespace Desafio.Desafio.Models
{

    /// <summary>
    /// Define uma <see cref="Consulta"/> de um consultório odontológico.
    /// </summary>
    public class Consulta
    {
        public long CPF { get; private set; }
        public DateTime DtConsulta { get; private set; }
        public DateTime HrInicial { get; private set; }
        public DateTime HrFinal { get; private set; }
        public TimeSpan Tempo { get => HrFinal - HrInicial; }

        /// <summary>
        /// Cria uma instância da <see cref="Consulta"/> com os argumentos utilizados.
        /// </summary>
        ///<param name = "CPF">Representa o valor da propriedade <see cref="CPF" />, deve possuir o valor de um CPF cadastrado na lista de Pacientes.</param>
        ///<param name = "DtConsulta">Representa o valor da propriedade <see cref="DtConsulta" />, deve possuir o formato DD/MM/AAAA e ser de um período futuro.</param>
        ///<param name = "HrInicial">Representa o valor da propriedade <see cref="HrInicial" />, deve possuir o formato HHMM, ser de um período futuro e estar no limite do horário de funcionamento do consultório, 8:00h às 19:00h, e ser definida sempre de 15 em 15 minutos(Ex. 1400, 1730, 1615).</param>
        ///<param name = "HrFinal">Representa o valor da propriedade <see cref="HrFinal" />, deve possuir o formato HHMM, ser de um período futuro maior que a propriedade <see cref="HrInicial"/>, estar no limite do horário de funcionamento do consultório, 8:00h às 19:00h, e ser definida sempre de 15 em 15 minutos(Ex. 1400, 1730, 1615).</param>
        public Consulta(long CPF, DateTime DtConsulta, DateTime HrInicial, 
            DateTime HrFinal)
        {
            this.CPF = CPF;
            this.DtConsulta = DtConsulta;
            this.HrInicial = HrInicial;
            this.HrFinal = HrFinal;
        }
    }
}

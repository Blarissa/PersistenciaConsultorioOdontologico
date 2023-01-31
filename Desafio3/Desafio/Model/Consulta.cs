namespace Desafio.Desafio.Models
{

    /// <summary>
    /// Define uma <see cref="Consulta"/> de um consultório odontológico.
    /// </summary>
    public class Consulta
    {

        /// <summary>
        /// Recebe um <see cref="Paciente"/> para a <see cref="Consulta"/>.
        /// </summary>
        public Paciente Paciente { get; private set; }
        /// <summary>
        /// Recebe a data e hora inicial da <see cref="Consulta"/>.
        /// </summary>
        public DateTime DataHoraInicial { get; private set; }
        /// <summary>
        /// Recebe a data e hora final da <see cref="Consulta"/>.
        /// </summary>
        public DateTime DataHoraFinal { get; private set; }
        /// <summary>
        /// Recebe o tempo da <see cref="Consulta"/> definido por: <code>DataHoraFinal - DataHoraInicial;</code>
        /// </summary>
        public TimeSpan Tempo { get => DataHoraFinal - DataHoraInicial; }

        /// <summary>
        /// Cria uma instância da <see cref="Consulta"/> com os argumentos utilizados.
        /// </summary>
        ///<param name = "paciente">Representa o valor da propriedade <see cref="Paciente" />, 
        ///<br>deve possuir o valor de um CPF cadastrado na lista de Pacientes.</br>
        ///</param>
        ///<param name = "dataHoraInicial">Representa o valor da propriedade <see cref="DataHoraInicial" />,
        ///<br>A <see langword="data"/> deve possuir:</br>
        ///<list type="bullet">
        ///<item>formato DD/MM/AAAA;</item>
        ///<item>e ser de um período futuro.</item>
        ///</list>
        ///<br>A <see langword="hora inicial"/> deve possuir:</br>
        ///<list type="bullet">
        ///<item>o formato HHMM;</item>
        ///<item>ser de um período futuro;</item>
        ///<item>estar no limite do horário de funcionamento do consultório, 8:00h às 19:00h; e</item>
        ///<item>ser definida sempre de 15 em 15 minutos(Ex. 1400, 1730, 1615).</item>
        ///</list>
        ///</param>
        ///<param name = "dataHoraFinal">Representa o valor da propriedade <see cref="DataHoraFinal"/>, 
        ///<br>A <see langword="data"/> deve possuir:</br>
        ///<list type="bullet">
        ///<item>formato DD/MM/AAAA;</item>
        ///<item>e ser de um período futuro.</item>
        ///</list>
        ///<br>A <see langword="hora final"/> deve possuir:</br>
        ///<list type="bullet">
        ///<item>o formato HHMM;</item>
        ///<item>ser de um período futuro;</item>
        ///<item>ser de um período futuro maior que a propriedade <paramref name="dataHoraInicial"/>;</item>
        ///<item>estar no limite do horário de funcionamento do consultório, 8:00h às 19:00h; e</item>
        ///<item>ser definida sempre de 15 em 15 minutos(Ex. 1400, 1730, 1615).</item>
        ///</list>
        ///</param>
        public Consulta(Paciente paciente, DateTime dataHoraInicial, DateTime dataHoraFinal)
        {
            this.Paciente = paciente;
            this.DataHoraInicial = dataHoraInicial;
            this.DataHoraFinal = dataHoraFinal;
        }

        /// <summary>
        /// Sobreescreve método <see langword="ToString"/>.
        /// </summary>
        /// <returns>Uma <see langword="string"/> contendo dados do <see cref="Consulta"/>.</returns>
        public override string ToString()
        {
            return $"{this.DataHoraInicial:t} "
                 + $"{this.DataHoraFinal:t} "
                 + $"{this.Tempo:hh\\:mm} " 
                 + $"{this.Paciente.Nome} "
                 + $"{this.Paciente.DtNascimento:d}\n";
        }

        /// <summary>
        /// Sobreescreve método <see langword="Equals"/>.        
        /// </summary>
        /// <param name="obj">Representa um objeto de <see cref="Consulta"/>.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// Retorna <see langword="true"/> 
        /// <list type="bullet">
        /// <item>se a <see cref="Consulta"/> tiver o mesmo <see cref="Paciente"/>.</item>
        /// <item>se a <see cref="Consulta"/> tiver a mesma <see cref="DataHoraInicial"/>.</item>       
        /// </list>
        /// </item>
        /// <item>
        /// Retorna <see langword="false"/> caso contrário.
        /// </item>
        /// </list>
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Consulta consulta &&
                   EqualityComparer<Paciente>.Default.Equals(this.Paciente, consulta.Paciente) &&
                   this.DataHoraInicial.Equals(consulta.DataHoraInicial);
        }

/// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Paciente, DataHoraInicial);
        }
    }
}

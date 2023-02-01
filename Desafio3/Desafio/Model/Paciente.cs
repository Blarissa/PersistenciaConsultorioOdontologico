using Desafio.Controller;

namespace Desafio.Model
{
    /// <summary>
    /// Define um <see cref="Paciente"/> de um consultório odontológico.
    /// </summary>
    public class Paciente
    {
        /// <summary>
        /// Recebe o CPF do <see cref="Paciente"/>.
        /// </summary>
        public long CPF { get; private set; }
        /// <summary>
        /// Recebe o nome do <see cref="Paciente"/>.
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Recebe a Data de nascimento do <see cref="Paciente"/>.
        /// </summary>
        public DateTime DtNascimento { get; private set; }
        /// <summary>
        /// Recebe a Idade do <see cref="Paciente"/> definida pela <see cref="DtNascimento"/>.
        /// </summary>
        public int Idade { get => DateTime.Now.Subtract(DtNascimento).Days / 365; }

        /// <summary>
        /// Inicia uma intância de classe <see cref="Paciente"/>.
        /// </summary>
        public Paciente() { }

        /// <summary>
        /// Cria uma instância de <see cref="Paciente"/> com os argumentos utilizados.
        /// </summary>
        ///<param name = "CPF"> Representa o valor da propriedade <see cref="CPF"/>, deve 
        ///<br>possuir o valor válido e não existir outro <see cref="Paciente"/></br>
        ///<br> com o mesmo <paramref name="CPF"/>.</br>
        ///</param>
        ///<param name = "Nome">Representa o valor da propriedade <see cref="Nome"/>, deve 
        ///<br>possuir pelo menos 5 caracteres.</br> 
        ///</param>
        ///<param name = "DtNascimento">Representa o valor da propriedade <see cref="DtNascimento"/>, 
        ///<br>deve possuir o formato DD/MM/AAAA e o <see cref="Paciente"/> deve</br>
        ///<br>ter 13 anos ou mais no momento do cadastro.</br>
        ///</param>        
        public Paciente(long CPF, string Nome, DateTime DtNascimento)
        {
            this.CPF = CPF;
            this.Nome = Nome;
            this.DtNascimento = DtNascimento;
        }

        /// <summary>
        /// Sobreescreve método <see langword="ToString"/>.
        /// </summary>
        /// <returns>Uma <see langword="string"/> contendo dados do <see cref="Paciente"/>.</returns>
        public override string ToString()
        {            
            return $"{this.CPF,-11:00000000000} " +
                   $"{this.Nome,-33} " +                   
                   $"{this.DtNascimento:d} " +
                   $"{this.Idade}\n";
        }

        /// <summary>
        /// Sobreescreve método <see langword="Equals"/>.        
        /// </summary>
        /// <param name="obj">Representa um objeto de <see cref="Paciente"/>.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// Retorna <see langword="true"/> se o <see cref="Paciente"/> tiver o mesmo <see cref="Paciente.CPF"/>
        /// que o <paramref name="obj"/> passado.
        /// </item>
        /// <item>
        /// Retorna <see langword="false"/> caso contrário.
        /// </item>
        /// </list>
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Paciente paciente &&
                   this.CPF.Equals(paciente.CPF);
        }

/// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(CPF);
        }
    }
}

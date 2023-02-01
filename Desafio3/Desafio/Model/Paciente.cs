using Desafio.Controller;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CPF { get;  set; }
        /// <summary>
        /// Recebe o nome do <see cref="Paciente"/>.
        /// </summary>
        [MinLength(5, ErrorMessage = "Nome do pacinete deve ter no mínimo 5 letras!")]
        public string Nome { get;  set; }
        /// <summary>
        /// Recebe a Data de nascimento do <see cref="Paciente"/>.
        /// </summary>

        [Column(TypeName = "date")]
        public DateTime DtNascimento { get;  set; }
        

        
        /// <summary>
        /// Sobreescreve método <see langword="ToString"/>.
        /// </summary>
        /// <returns>Uma <see langword="string"/> contendo dados do <see cref="Paciente"/>.</returns>
        public override string ToString()
        {
            return $"{this.CPF,-11:00000000000} " +
                   $"{this.Nome,-33} " +
                   $"{this.DtNascimento:d} idade";
                  
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

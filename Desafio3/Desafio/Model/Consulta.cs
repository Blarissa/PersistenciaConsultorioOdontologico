using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Model
{

    /// <summary>
    /// Define uma <see cref="Consulta"/> de um consultório odontológico.
    /// </summary>
    public class Consulta
    {

        /// <summary>
        /// Recebe um identificador para uma <see cref="Consulta"/>.
        /// </summary>
        [Key]
        public int Id { get; set; }

        [ForeignKey("Paciente")]
        public long CPFPaciente { get; set; }
        /// <summary>
        /// Recebe um <see cref="Paciente"/> para a <see cref="Consulta"/>.
        /// </summary>
        public Paciente Paciente { get; set; }
        /// <summary>
        /// Recebe a data e hora inicial da <see cref="Consulta"/>.
        /// </summary>
        [Column(TypeName = "timestamp")]
        public DateTime DataHoraInicial { get; set; }
        /// <summary>
        /// Recebe a data e hora final da <see cref="Consulta"/>.
        /// </summary>
        [Column(TypeName = "timestamp")]
        public DateTime DataHoraFinal { get; set; }
        
        

        /// <summary>
        /// Sobreescreve método <see langword="ToString"/>.
        /// </summary>
        /// <returns>Uma <see langword="string"/> contendo dados do <see cref="Consulta"/>.</returns>
        public override string ToString()
        {
            return $"{DataHoraInicial:t} "
                 + $"{DataHoraFinal:t} "
                 + $"{DataHoraFinal.Subtract(DataHoraInicial).ToString("hh\\:mm")} " 
                 + $"{Paciente.Nome} "
                 + $"{Paciente.DtNascimento:d}\n";
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

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Model
{
    #region Documentation
    /// <summary>   Define uma <see cref="Consulta"/> de um consultório odontológico. </summary>    
    #endregion

    public class Consulta
    {
        #region Documentation
        /// <summary>   Recebe um identificador para uma <see cref="Consulta"/>. </summary>
        #endregion

        [Key]
        public int Id { get; set; }

        #region Documentation
        /// <summary>   Recebe um identificador do <see cref="Paciente"/>. </summary>
        #endregion

        [ForeignKey("Paciente")]
        public long CPFPaciente { get; set; }

        #region Documentation
        /// <summary>   Recebe um <see cref="Paciente"/> para a <see cref="Consulta"/>. </summary>       
        #endregion

        public Paciente Paciente { get; set; }

        #region Documentation
        /// <summary>   Recebe a data e hora inicial da <see cref="Consulta"/>. </summary>        
        #endregion

        [Column(TypeName = "timestamp")]
        public DateTime DataHoraInicial { get; set; }

        #region Documentation
        /// <summary>   Recebe a data e hora final da <see cref="Consulta"/>. </summary>
        #endregion

        [Column(TypeName = "timestamp")]
        public DateTime DataHoraFinal { get; set; }

        #region Documentation
        /// <summary>   Retorna o <see langword="tempo"/> da <see cref="Consulta"/>. </summary>        
        #endregion

        public TimeSpan Tempo()
        {
            return DataHoraFinal.Subtract(DataHoraInicial);
        }

        #region Documentation
        /// <summary>   Realiza a listagem das <paramref name="consultas"/>. </summary>
        ///
        /// <param name="consultas">
        ///     <see cref="IList{T}"/> de <paramref name="consultas"/> que serão mostrados.
        /// </param>
        ///
        /// <returns>
        ///     Uma <see cref="string"/> com a listagem dos <paramref name="consultas"/> ordenadas por <see cref="DataHoraInicial"/>.
        /// </returns>
        #endregion

        public static string Listar(IList<Consulta> consultas)
        {
            string str = "".PadRight(61, '-') + "\n" + "".PadLeft(3)
                       + $"{"Data"} " + "".PadRight(3) 
                       + $"{"H.Ini"} "
                       + $"{"H.Fim"} " 
                       + $"{"Tempo"} " 
                       + $"{"Nome"} " 
                       + $"{"Dt.Nasc.",26} \n"
                       + "".PadRight(61, '-') + "\n";

            //Agrupando consultas por data
            var query = consultas.GroupBy(c => c.DataHoraInicial);

            //Listando consultas agrupadas por data
            foreach (var result in query)
            {
                str += $"{result.Key:d} ";

                foreach (Consulta c in result)
                {
                    str += $"{c.DataHoraInicial:t} "
                     + $"{c.DataHoraFinal:t} "
                     + $"{c.Tempo():hh\\:mm} "
                     + $"{c.Paciente.Nome} "
                     + $"{c.Paciente.DtNascimento:d}\n";
                }
            }

            return str;
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

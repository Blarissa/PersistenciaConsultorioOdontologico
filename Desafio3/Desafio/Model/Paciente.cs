using Desafio.Controller;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Model

{
    #region Documentation
    /// <summary>   Define um <see cref="Paciente"/> de um consultório odontológico. </summary>
    #endregion

    public class Paciente
    {
        #region Documentation
        /// <summary>   Recebe o CPF do <see cref="Paciente"/>. </summary>
        #endregion

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CPF { get; set; }

        #region Documentation
        /// <summary>   Recebe o nome do <see cref="Paciente"/>. </summary>
        #endregion

        [MinLength(5, ErrorMessage = "Nome do paciente deve ter no mínimo 5 letras!")]
        public string Nome { get; set; }

        #region Documentation
        /// <summary>   Recebe a Data de nascimento do <see cref="Paciente"/>. </summary>
        #endregion

        [Column(TypeName = "date")]
        public DateTime DtNascimento { get; set; }

        #region Documentation
        /// <summary>   Retorna a <see langword="idade"/> do <see cref="Paciente"/>. </summary>
        #endregion

        private int Idade => DateTime.Now.Subtract(DtNascimento).Days / 365;

        #region Documentation
        /// <summary>   Realiza a listagem dos <paramref name="pacientes"/>. </summary>        
        /// <param name="pacientes">
        ///     <see cref="IList{T}"/> de <paramref name="pacientes"/> que serão mostrados.
        /// </param>
        ///
        /// <returns>
        ///     Uma <see cref="string"/> com a listagem dos <paramref name="pacientes"/>, se o <see cref="Paciente">
        ///     paciente</see> tiver consultas futuras agendadas elas também serão mostradas.
        /// </returns>
        #endregion

        public static string Listar(IList<Paciente> pacientes)
        {
            string str = Cabecalho();

            pacientes.ForEach(p => str += p.ToString());

            return str;
        }

        #region Documentation
        /// <summary>   Realiza a listagem de um <paramref name="paciente"/>. </summary>        
        /// <param name="paciente">
        ///     <paramref name="paciente"/> que será mostrado.
        /// </param>
        ///
        /// <returns>
        ///     Uma <see cref="string"/> com a listagem do <paramref name="paciente"/>, se o <see cref="Paciente">
        ///     paciente</see> tiver consultas futuras agendadas elas também serão mostradas.
        /// </returns>
        #endregion

        public string Listar()
        {
            string str = Cabecalho() + ToString();
            return str;
        }

        #region Documentation
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Laris, 05/02/2023. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        #endregion

        public override string ToString()
        {
            string str = $"{CPF,-11:00000000000} "
                       + $"{Nome,-33} "
                       + $"{DtNascimento:d} "
                       + $"{Idade}\n";

            var consultas = new ConsultaController().ListarPorCPF(CPF);

            var query = from c in consultas
                        where c.DataHoraInicial >= DateTime.Now
                        select c;

            if (query.HasItems())
                consultas.ForEach(c =>
                    str += $"{"",-11} "
                         + $"Agendado para: {c.DataHoraInicial.Date:d}\n"
                         + $"{"",-11} {c.DataHoraInicial:t} às {c.DataHoraFinal:t}\n");

            return str;
        }

        #region Documentation
        /// <summary>   Gets the cabecalho. </summary>
        ///
        /// <remarks>   Laris, 05/02/2023. </remarks>
        ///
        /// <returns>   A string. </returns>
        #endregion

        private static string Cabecalho()
        {
            return "".PadRight(60, '-') + "\n"
                       + $"{"CPF",-11} {"Nome",-33} {"Dt.Nasc."} {"Idade"}\n"
                       + "".PadRight(60, '-') + "\n";
        }

        #region Documentation
        /// <summary>   Sobreescreve método <see langword="Equals"/>. </summary>
        ///
        /// <param name="obj">  Representa um objeto de <see cref="Paciente"/>. </param>
        ///
        /// <returns>
        ///     <list type="bullet">
        ///     <item>
        ///     Retorna <see langword="true"/> se o <see cref="Paciente"/> tiver o mesmo <see cref="Paciente.CPF"/>
        ///     que o <paramref name="obj"/> passado.
        ///     </item>
        ///     <item>
        ///     Retorna <see langword="false"/> caso contrário.
        ///     </item>
        ///     </list>
        /// </returns>
        #endregion

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
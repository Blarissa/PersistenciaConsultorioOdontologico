using ConversorMonetario.ConversorMonetario.Views;

namespace ConversorMonetario.ConversorMonetario.Controllers
{
    /// <summary>
    /// Define a validação dos dados.
    /// </summary>
    internal class Valida
    {
        /// <summary>
        /// Determina se o símbolo da <see cref="EntradaDeDados.MoedaDeOrigem"/> e da <see cref="EntradaDeDados.MoedaDeDestino"/> são iguais.
        /// </summary>
        /// <param name="moeda1"> Representa o valor da <see cref="EntradaDeDados.MoedaDeOrigem"/>.</param>
        /// <param name="moeda2"> Representa o valor da <see cref="EntradaDeDados.MoedaDeDestino"/>.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>Retorna <see langword="true"/> se as duas moedas forem iguais.</item>
        /// <item>Retorna <see langword="false"/> se não forem.</item>
        /// </list></returns>
        public static bool MoedasIguais(string moeda1, string moeda2)
        {
            return moeda1.Equals(moeda2);
        }

        /// <summary>
        /// Determina se o símbolo da <see langword="moeda"/> está no formato correto.
        /// </summary>
        /// <param name="moeda"> Representa o valor de uma <see langword="moeda"/> a ser inserida.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>Retorna <see langword="true"/> se a moeda tiver exatamente 3 caracteres.</item>
        /// <item>Retorna <see langword="false"/> se não tiver.</item>
        /// </list></returns>
        public static bool MoedaFormato(string moeda)
        {
            return moeda.Count() == 3;
        }

        /// <summary>
        /// Determina se a <see cref="EntradaDeDados.Valor"/> tem valor maior que 0.
        /// </summary>
        /// <param name="valor">Representa o <see cref="EntradaDeDados.Valor"/> a ser avaliada.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>Retorna <see langword="true"/> se o <see cref="EntradaDeDados.Valor"/>for maior que 0</item>
        /// <item>Retorna <see langword="false"/> se não for.</item>
        /// </list></returns>
        public static bool Valor(decimal valor)
        {
            return valor > 0;
        }

        /// <summary>
        /// Determina se a <see cref="EntradaDeDados.Valor"/> tem o formato esperado,<br>ou seja, se tem 2 casa decimais.</br>
        /// </summary>
        /// <param name="valor">Representa o <see cref="EntradaDeDados.Valor"/> a ser avaliada.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>Retorna <see langword="true"/> se o <see cref="EntradaDeDados.Valor"/> tiver 2 casas decimais.</item>
        /// <item>Retorna <see langword="false"/> se não tiver.</item>
        /// </list></returns>        
        public static bool ValorFormato(decimal valor)
        {
            return valor.Scale.Equals(2);
        }

        /// <summary>
        /// Determina se o símbolo da <see langword="Moeda"/> existe na lista de <see cref="Simbolos"/>.
        /// </summary>
        /// <param name="permitidos">Representa o valor de uma lista com os <see cref="Simbolos.Permitidos"/>.</param>
        /// <param name="moeda">Representa o valor do símbolo de uma moeda <see langword="Moeda"/>, <br>que será buscado na lista de <see cref="Simbolos.Permitidos"/></br>.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>Retorna <see langword="true"/> se a <see langword="Moeda"/> existir na lista de <see cref="Simbolos.Permitidos"/>.</item>
        /// <item>Retorna <see langword="false"/> se não existir.</item>
        /// </list></returns>  
        public static bool MoedaExiste(List<string> permitidos, string moeda)
        {
            return permitidos.Contains(moeda.ToUpper());
        }
    }
}
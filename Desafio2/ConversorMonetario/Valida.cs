namespace ConversorMonetario
{
    /// <summary>
    /// Define a validação dos dados.
    /// </summary>
    internal class Valida
    {
        /// <summary>
        /// Compara se duas moedas são iguais.
        /// </summary>
        /// <param name="moeda1"> Representa o valor da <see cref="EntradaDeDados.MoedaDeOrigem"/>.</param>
        /// <param name="moeda2">Representa o valor da <see cref="EntradaDeDados.MoedaDeDestino"/>.</param>
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
        /// Valida o formato da moeda
        /// </summary>
        /// <param name="moeda"> Representa uma <see langword="moeda"/> que deve ter exatamente 3 caracteres.</param>
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
        /// Determina se o <see cref="EntradaDeDados.Valor"/> é maior que 0.
        /// </summary>
        /// <param name="valor">Representa o <see cref="EntradaDeDados.Valor"/>.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>Retorna <see langword="true"/> se o <see cref="EntradaDeDados.Valor"/>for maior que 0</item>
        /// <item>Retorna <see langword="false"/> se não for.</item>
        /// </list></returns>
        public static bool Valor(double valor)
        {
            return valor > 0;
        }

        /// <summary>
        /// Determina se o <see cref="EntradaDeDados.Valor"/> tem 2 casa decimais.
        /// </summary>
        /// <param name="valor">Representa o <see cref="EntradaDeDados.Valor"/>.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>Retorna <see langword="true"/> se o <see cref="EntradaDeDados.Valor"/> tiver 2 casas decimais.</item>
        /// <item>Retorna <see langword="false"/> se não tiver.</item>
        /// </list></returns>        
        public static bool ValorFormato(double valor)
        {
            return valor.ToString("F").Equals(valor.ToString());
        }
    }
}

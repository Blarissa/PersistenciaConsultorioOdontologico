namespace ConversorMonetario.ConversorMonetario.Views
{
    /// <summary>
    /// Define a <see langword="Entrada de dados"/> da aplicação.
    /// </summary>
    internal class EntradaDeDados
    {
        /// <summary>
        /// Realiza a leitura do valor da <see cref="MoedaDeOrigem"/>.
        /// </summary>
        /// <returns>Retorna uma <see langword="string"/> que foi inserida no console.</returns>
        public static string MoedaDeOrigem()
        {
            Console.WriteLine("Moeda de origem: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Realiza a leitura do valor da <see cref="MoedaDeDestino"/>.
        /// </summary>
        /// <returns>Retorna uma <see langword="string"/> que foi inserida no console.</returns>
        public static string MoedaDeDestino()
        {
            Console.WriteLine("Moeda de destino: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Realiza a leitura do <see cref="ValorDeEntrada"/>.
        /// </summary>
        /// <returns>Retorna um <see langword="decimal"/> que foi inserido no console.</returns>
        public static decimal? ValorDeEntrada()
        {
            Console.WriteLine("Valor: ");
            return decimal.Parse(Console.ReadLine());
        }
    }
}

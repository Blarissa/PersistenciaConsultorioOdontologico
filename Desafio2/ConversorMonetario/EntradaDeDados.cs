namespace ConversorMonetario
{
    /// <summary>
    /// Define a <see langword="Entrada de dados"/> da aplicação.
    /// </summary>
    internal class EntradaDeDados
    {
        /// <summary>
        /// Realiza a leitura da <see cref="MoedaDeOrigem"/>.
        /// </summary>
        /// <returns>Retorna uma <see langword="string"/> inserida no console.</returns>
        public static string MoedaDeOrigem()
        {
            Console.WriteLine("Moeda de origem: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Realiza a leitura da <see cref="MoedaDeDestino"/>.
        /// </summary>
        /// <returns>Retorna uma <see langword="string"/> inserida no console.</returns>
        public static string MoedaDeDestino()
        {
            Console.WriteLine("Moeda de destino: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Realiza a leitura do <see cref="ValorDeEntrada"/>.
        /// </summary>
        /// <returns>Retorna um <see langword="double"/> inserido no console.</returns>
        public static decimal? ValorDeEntrada()
        {
            Console.WriteLine("Valor: ");
            return decimal.Parse(Console.ReadLine());
        }
    }
}

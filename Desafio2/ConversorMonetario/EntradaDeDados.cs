namespace ConversorMonetario
{
    internal class EntradaDeDados
    {
        public static string MoedaDeOrigem()
        {
            Console.WriteLine("Moeda de origem: ");
            return Console.ReadLine();
        }

        public static string MoedaDeDestino()
        {
            Console.WriteLine("Moeda de destino: ");
            return Console.ReadLine();
        }

        public static double? Valor()
        {
            Console.WriteLine("Valor: ");
            return double.Parse(Console.ReadLine());
        }
    }
}

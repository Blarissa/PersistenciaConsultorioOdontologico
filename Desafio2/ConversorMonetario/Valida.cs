namespace ConversorMonetario
{
    internal class Valida
    {
        public static bool MoedasIguais(string moeda1, string moeda2)
        {
            return moeda1.Equals(moeda2);
        }

        public static bool MoedaFormato(string moeda)
        {
            return moeda.Count() == 3;
        }

        public static bool Valor(double valor)
        {
            return valor > 0;
        }

        public static bool ValorFormato(double valor)
        {
            return valor.ToString("F").Equals(valor.ToString());
        }
    }
}

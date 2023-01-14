namespace ConversorMonetario
{
    internal class Controler
    {
        public string MoedaDeOrigemValida()
        {
            var moeda = EntradaDeDados.MoedaDeOrigem();

            if (string.IsNullOrEmpty(moeda))
                Environment.Exit(0);
            else if (!Valida.MoedaFormato(moeda))
            {
                Console.WriteLine("Moeda de origem deve ter exatamante 3 caracteres!");
                return MoedaDeOrigemValida();
            }
            return moeda;
        }

        public string MoedaDeDestinoValida(string moedaDeOrigem)
        {
            var moedaDeDestino = EntradaDeDados.MoedaDeDestino();

            if (!Valida.MoedaFormato(moedaDeDestino) ||
                string.IsNullOrEmpty(moedaDeDestino))
            {
                Console.WriteLine("Moeda de destino deve ter exatamante 3 caracteres!");
                return MoedaDeDestinoValida(moedaDeOrigem);
            }
            else if (Valida.MoedasIguais(moedaDeOrigem, moedaDeDestino))
            {
                Console.WriteLine("Moeda de destino deve ser diferente da moeda de origem!");
                return MoedaDeDestinoValida(moedaDeOrigem);
            }

            return moedaDeDestino;
        }

        public decimal ValorEntradaValido()
        {
            var valor = EntradaDeDados.ValorDeEntrada();

            if (!valor.HasValue)
            {
                Console.WriteLine("Valor de entrada nulo!");
                return ValorEntradaValido();
            }
            else if (!Valida.ValorFormato(valor.Value))
            {
                Console.WriteLine("Valor de entrada deve ter 2 casa decimais!");
                return ValorEntradaValido();
            }
            else if (!Valida.Valor(valor.Value))
            {
                Console.WriteLine("Valor de entrada deve ser maior que 0!");
                return ValorEntradaValido();
            }
            return valor.Value;
        }
    }
}



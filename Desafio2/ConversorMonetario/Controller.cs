using System;
using System.Collections;
using System.Globalization;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConversorMonetario
{
    internal class Controller 
    {                 
        public string MoedaDeOrigemValida(List<string> permitidos)
        {
            var moeda = EntradaDeDados.MoedaDeOrigem();

            if (string.IsNullOrEmpty(moeda))
                Environment.Exit(0);
            else if (!Valida.MoedaFormato(moeda))
            {
                Console.WriteLine("\nMoeda de origem deve ter exatamante 3 caracteres!\n");
                return MoedaDeOrigemValida(permitidos);
            }else if(!Valida.MoedaExiste(permitidos, moeda))
            {
                Console.WriteLine("\nMoeda de origem não existe!\n");
                return MoedaDeOrigemValida(permitidos);
            }
            return moeda;
        }

        public string MoedaDeDestinoValida(List<string> permitidos, string moedaDeOrigem)
        {
            var moedaDeDestino = EntradaDeDados.MoedaDeDestino();

            if (!Valida.MoedaFormato(moedaDeDestino) ||
                string.IsNullOrEmpty(moedaDeDestino))
            {
                Console.WriteLine("\nMoeda de destino deve ter exatamante 3 caracteres!\n");
                return MoedaDeDestinoValida(permitidos, moedaDeOrigem);
            }
            else if (Valida.MoedasIguais(moedaDeOrigem, moedaDeDestino))
            {
                Console.WriteLine("\nMoeda de destino deve ser diferente da moeda de origem!\n");
                return MoedaDeDestinoValida(permitidos, moedaDeOrigem);
            }
            else if (!Valida.MoedaExiste(permitidos, moedaDeDestino))
            {
                Console.WriteLine("\nMoeda de destino não existe!\n");
                return MoedaDeDestinoValida(permitidos,moedaDeOrigem);
            }

            return moedaDeDestino;
        }

        public decimal ValorEntradaValido()
        {
            var valor = EntradaDeDados.ValorDeEntrada();

            if (!valor.HasValue)
            {
                Console.WriteLine("\nValor de entrada nulo!\n");
                return ValorEntradaValido();
            }
            else if (!Valida.ValorFormato(valor.Value))
            {
                Console.WriteLine("\nValor de entrada deve ter 2 casa decimais!\n");
                return ValorEntradaValido();
            }
            else if (!Valida.Valor(valor.Value))
            {
                Console.WriteLine("\nValor de entrada deve ser maior que 0!\n");
                return ValorEntradaValido();
            }
            return valor.Value;
        }

        public void Status(HttpResponseMessage response)
        {
            Console.WriteLine($"\nStatus: {response.StatusCode}\n");
        }

        public void MostrarResultados(Resultado resultado)
        {
            Console.WriteLine($"\nTaxa: {resultado.Taxa}" +
                $"\nValor convertido: {resultado.Convertido}\n");
        }

        public string URIParaConversao(List<string> permitidos)
        {
            var origem = new Controller().MoedaDeOrigemValida(permitidos);
            var destino = new Controller().MoedaDeDestinoValida(permitidos, origem);
            var valor = new Controller().ValorEntradaValido();

            return $"https://api.exchangerate.host/convert?from={origem}&to={destino}&amount={valor}";
        }        
    }
}



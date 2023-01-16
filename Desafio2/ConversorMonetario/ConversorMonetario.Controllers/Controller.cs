using ConversorMonetario.ConversorMonetario.Views;

namespace ConversorMonetario.ConversorMonetario.Controllers
{
    internal class Controller
    {

        /// <summary>
        /// Realiza a inserção e validação da <see cref="EntradaDeDados.MoedaDeOrigem"/>.
        /// </summary>
        /// <param name="permitidos">Representa o valor de uma lista com os <see cref="Simbolos.Permitidos"/>.</param>        
        /// <remarks> 
        /// <list type="bullet">
        /// <item>Caso a <see cref="EntradaDeDados.MoedaDeOrigem"/> não tiver o formato válido; ou,</item>
        /// <item>Caso a <see cref="EntradaDeDados.MoedaDeOrigem"/> não existir na lista de <see cref="Simbolos.Permitidos"/> <br>o valor deverá ser inserido novamente.</br></item>
        /// <item>Mas caso a <see cref="EntradaDeDados.MoedaDeOrigem"/> for vazia ou nula a aplicação termina. </item>
        /// </list>
        /// </remarks>
        /// <returns>Retorna uma <see langword="string"/> que contém o símbolo da moeda de origem válida.</returns>
        public string MoedaDeOrigemValida(List<string> permitidos)
        {
            var moeda = EntradaDeDados.MoedaDeOrigem();

            if (string.IsNullOrEmpty(moeda))
                Environment.Exit(0);
            else if (!Valida.MoedaFormato(moeda))
            {
                Console.WriteLine("\nMoeda de origem deve ter exatamante 3 caracteres!\n");
                return MoedaDeOrigemValida(permitidos);
            }
            else if (!Valida.MoedaExiste(permitidos, moeda))
            {
                Console.WriteLine("\nMoeda de origem não existe!\n");
                return MoedaDeOrigemValida(permitidos);
            }
            return moeda;
        }

        /// <summary>
        /// Realiza a inserção e validação da <see cref="EntradaDeDados.MoedaDeDestino"/>.
        /// </summary>
        /// <param name="permitidos">Representa o valor de uma lista com os <see cref="Simbolos.Permitidos"/>.</param>
        /// <param name="moedaDeOrigem">Representa o valor da <see cref="EntradaDeDados.MoedaDeOrigem"/>.</param>
        /// <remarks> 
        /// <list type="bullet">
        /// <item>Caso a <see cref="EntradaDeDados.MoedaDeDestino"/> não tiver o formato válido; ou</item>
        /// <item>Caso a <see cref="EntradaDeDados.MoedaDeDestino"/> for vazia ou nula; ou </item>
        /// <item>Caso a <see cref="EntradaDeDados.MoedaDeDestino"/> for igual a <see cref="EntradaDeDados.MoedaDeOrigem"/>;ou</item>        
        /// <item>Caso a <see cref="EntradaDeDados.MoedaDeDestino"/> não existir na lista de <see cref="Simbolos.Permitidos"/> <br>o valor deverá ser inserido novamente.</br></item>        
        /// </list>
        /// </remarks>
        /// <returns>Retorna uma <see langword="string"/> que contém o símbolo da moeda de destino válida.</returns>
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
                return MoedaDeDestinoValida(permitidos, moedaDeOrigem);
            }

            return moedaDeDestino;
        }

        /// <summary>
        /// Realiza a inserção e validação da <see cref="EntradaDeDados.ValorDeEntrada"/>.
        /// </summary>
        /// <remarks> 
        /// <list type="bullet">
        /// <item>Caso a <see cref="EntradaDeDados.ValorDeEntrada"/> for vazia ou nula; ou</item>
        /// <item>Caso a <see cref="EntradaDeDados.ValorDeEntrada"/> não esteja em um formato válido; ou</item>
        /// <item>Caso a <see cref="EntradaDeDados.ValorDeEntrada"/> seja menor que 0, o valor deverá<br> ser inserido novamente.</br></item>
        /// </list>
        /// </remarks>
        /// <returns>Retorna um <see langword="decimal"/> que contém o valor a ser convertido.</returns>
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

        /// <summary>
        /// Imprime o status da requisão realizada pelo cliente.
        /// </summary>
        /// <param name="response"> Representa o valor de resposta para a requisição realizada.</param>
        public static void Status(HttpResponseMessage response)
        {
            Console.WriteLine($"\nStatus: {response.StatusCode}\n");
        }

        /// <summary>
        /// Imprime os resultados da conversão monetária realizada.
        /// </summary>
        /// <param name="resultado">Representa o <see cref="Resultado"/> recebido da requsição realizada.</param>
        public static void MostrarResultados(Resultado resultado)
        {
            var valorDeEntrada = Convert.ToDecimal(resultado.Query["amount"].ToString());

            Console.WriteLine("\n"
                + $"{"De| ",11} {resultado.Query["from"]}\n"
                + $"{"Valor| ",11} {valorDeEntrada:N2}\n"
                + $"{"Para| ",11} {resultado.Query["to"]}\n"
                + $"{"Resultado| "} {resultado.Convertido}\n"
                + $"{"Taxa| ",11} {resultado.Taxa}\n"
                );
        }

        /// <summary>
        /// Determina o URI a ser usado para a requição.
        /// </summary>
        /// <param name="permitidos">Representa o valor de uma lista com os <see cref="Simbolos.Permitidos"/>.</param>
        /// <returns>Retorna o URI da requisição.</returns>
        public static string URIParaConversao(List<string> permitidos)
        {
            var origem = new Controller().MoedaDeOrigemValida(permitidos);
            var destino = new Controller().MoedaDeDestinoValida(permitidos, origem);
            var valor = new Controller().ValorEntradaValido();

            return $"https://api.exchangerate.host/convert?from={origem}&to={destino}&amount={valor}";
        }
    }
}



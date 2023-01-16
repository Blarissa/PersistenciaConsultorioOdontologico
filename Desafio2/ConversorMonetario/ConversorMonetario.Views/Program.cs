using ConversorMonetario.ConversorMonetario.Controllers;
using System.Net.Http.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using HttpClient cliente = new();

        await ConverteMoeda(cliente);

        ///<summary>
        /// Define a lista de <see cref="Simbolos.Permitidos"/>.
        ///</summary>
        ///<param name="cliente">Representa o valor do <see cref="cliente"/>.</param>
        ///<returns>
        ///Retorna a lista de <see cref="Simbolos.Permitidos"/>.
        ///</returns>
        static async Task<List<string>> SimbolosPermitidos(HttpClient cliente)
        {
            var uri = "https://api.exchangerate.host/symbols";

            var permitidos = await cliente.GetFromJsonAsync<Simbolos>(uri);

            return permitidos.Permitidos;
        }

        ///<summary>
        /// Define a conversão monetária.
        ///</summary>
        ///<param name="cliente">Representa o valor do <see cref="cliente"/>.</param>       
        static async Task ConverteMoeda(HttpClient cliente)
        {
            var simbolosPermitidos = await SimbolosPermitidos(cliente);

            var uri = Controller.URIParaConversao(simbolosPermitidos);

            HttpResponseMessage response = await cliente.GetAsync(uri);
            Controller.Status(response);

            if (!response.IsSuccessStatusCode)
                await ConverteMoeda(cliente);

            Console.WriteLine("\nConvertendo...\n");
            Resultado resultado = await cliente.GetFromJsonAsync<Resultado>(uri);

            Controller.MostrarResultados(resultado);
            await ConverteMoeda(cliente);
        }
    }
}
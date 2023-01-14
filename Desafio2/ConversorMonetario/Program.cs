using ConversorMonetario;
using System.Text.Json;

internal class Program
{
    private static async Task Main()
    {
        using HttpClient client = new();
        await ConverteMoeda(client);

        static async Task ConverteMoeda(HttpClient client)
        {
            var origem = new Controler().MoedaDeOrigemValida();
            var destino = new Controler().MoedaDeDestinoValida(origem);
            var valor = new Controler().ValorEntradaValido();

            var uri = $"https://api.exchangerate.host/convert?from={origem}&to={destino}&amount={valor}";

            await using Stream stream =
            await client.GetStreamAsync(uri);
            var resultado = await JsonSerializer.DeserializeAsync<Resultado>(stream);

            Console.WriteLine($"Taxa: R$ {resultado.Info["rate"]}" + "\n" +
                              $"Valor: R$ {resultado.ValorConvertido}");
        }
    }
}
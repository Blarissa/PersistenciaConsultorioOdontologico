using System.Text.Json.Serialization;

public record class Resultado(
    [property: JsonPropertyName("info")] Dictionary<string, double> Info,
    [property: JsonPropertyName("result")] double ValorConvertido
    )
{
    public double Taxa = Math.Round(Info["rate"], 6);
    public double Convertido => Math.Round(ValorConvertido, 2);
}

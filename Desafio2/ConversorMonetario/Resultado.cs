using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Transactions;

public record class Resultado(
    [property: JsonPropertyName("info")] Dictionary<string, decimal> Info,
    [property: JsonPropertyName("result")] decimal ValorConvertido
    )
{
    public decimal Taxa = decimal.Round(Info["rate"], 6);
    public decimal Convertido = decimal.Round(ValorConvertido, 2);
}

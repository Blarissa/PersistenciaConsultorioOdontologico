using System.Collections;
using System.Text.Json.Serialization;

public record class Resultado(
    [property: JsonPropertyName("info")] Dictionary<string, decimal> Info,
    [property: JsonPropertyName("result")] decimal ValorConvertido,
    [property: JsonPropertyName("query")] Hashtable Query
    )
{
    public decimal Taxa = decimal.Round(Info["rate"], 6);
    public decimal Convertido = decimal.Round(ValorConvertido, 2);
}

public record class Simbolos([property: JsonPropertyName("symbols")] Hashtable Simbolo) { 
    public List<string> Permitidos = Simbolo.Keys.Cast<String>().ToList();
}

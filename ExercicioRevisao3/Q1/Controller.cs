using Nancy.Extensions;
using Nancy.Json;
using Nancy.ViewEngines;
using Newtonsoft.Json;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Q1
{
    internal class Controller   
    {

        //ler dados do arquivo JSON
        public static List<Hashtable> LerDados()
        {
            string url = @"C:\Users\laris\source\repos\Blarissa\ResidenciaIUUL\ExercicioRevisao3\Q1\clientes.json";

            String dados = File.ReadAllText(url);
            JsonDocument document = JsonDocument.Parse(
                dados, new JsonDocumentOptions() { 
                    CommentHandling = JsonCommentHandling.Skip
                });
            JsonElement jsonElement = document.RootElement;

            return jsonElement.Deserialize<List<Hashtable>>();
        }
      
        public static void GravaErros(List<Erro> lista)
        {
            JsonDocument documentoJson = JsonDocument.Parse(lista.ToString());
            FileStream fs = File.OpenWrite(@"erros.json");

            Utf8JsonWriter writer = new (fs, new JsonWriterOptions { 
                Indented = true 
            });

            documentoJson.WriteTo(writer);
        }
        
        //valida dados dos clientes
        public void Adiciona()
        {
            List<Hashtable> clientesDados = LerDados();
            List<Erro> erros = new();
            Valida valida;

            foreach (Hashtable cliente in clientesDados)
            {
                valida = new(cliente["nome"].ToString(),
                                cliente["cpf"].ToString(),
                                cliente["dt_nascimento"].ToString(),
                                cliente["renda_mensal"].ToString(),
                                cliente["estado_civil"].ToString(),
                                cliente["dependentes"].ToString());

                if (!valida.E.IsNull())
                {
                    erros.Add(valida.E);
                }
            }

            GravaErros(erros);
        }            
    }
}

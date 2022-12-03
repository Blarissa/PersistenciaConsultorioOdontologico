using Nancy.Extensions;
using Nancy.Json;
using Nancy.ViewEngines;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Q1
{
    internal class Controller   
    {

        //ler dados do cliente arquivo JSON
        public static List<ClienteJson> LerDados()
        {
            //lendo dados do arquivo JSON
            String dados = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory
                                          + @"\clientes.json");
            
            //retornando lista de clientesJson
            return JsonConvert.DeserializeObject<List<ClienteJson>>(dados);
        }
        
        // grava erros em um arquivo JSON
        public static void GravaErros(List<Erro> erros)
        {   //convertendo lista em arquivo JSON
            string errosJson = JsonConvert.SerializeObject(erros, Formatting.Indented); 
            //criando arquivo
            File.WriteAllText(@"erros.json", errosJson);
        }
        
        //adiciona dados errados em um arquivo JSON
        public static void AddErros()
        {
            //Lendo dados do arquivo
            List<ClienteJson> clienteJson = LerDados();

            //criando lista de erro 
            List<Erro> erros = new();
            Valida valida;

            //valida dados do arquivo
            foreach (ClienteJson cliente in clienteJson){
                valida = new(cliente.nome,
                                cliente.cpf,
                                cliente.dt_nascimento,
                                cliente.renda_mensal,
                                cliente.estado_civil,
                                cliente.dependentes);
               
                //se existe erros nos dadosdo arquivo adiciona na lista
                if (valida.E.Erros.Count > 0)
                    erros.Add(valida.E);              
            }
            //gravando erros em um arquivo
            GravaErros(erros);            
        }            
        /*
        public void AddComConsole()
        {
            Console.WriteLine("Insira seus dados");
            Console.WriteLine("Nome (pelo menos 5 caracteres): ");
            string nome = Console.ReadLine();

            Console.WriteLine("Cpf (11 digitos): ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Data de Nascimento (não pode ser menor que 18 anos): ");
            string dataNascimento = Console.ReadLine();

            Console.WriteLine("Renda (maior que 0 e com 2 casa decimais): ");
            string renda = Console.ReadLine();

            Console.WriteLine(
                "\nC - Casado" +
                "\nS - Solteiro" +
                "\nV - Viuvo" +
                "\nD - Divorciado\n" +
                "\nEstado civil: ");
            string estadoCivil = Console.ReadLine();

            Console.WriteLine("Dependentes (entre 0 e 10): ");
            string dependentes = Console.ReadLine();

            Valida valida = new(nome, cpf, dataNascimento, renda, estadoCivil, dependentes);
        }

        public Hashtable AddNovamente(Valida valida)
        {
            Hashtable campos = new Hashtable();
            campos.Add("nome","");
            campos.Add("cpf", "");
            campos.Add("dt_nascimento", "");
            campos.Add("renda_mensal", "");
            campos.Add("estado_civil", "");
            campos.Add("dependentes", "");
            foreach (string campo in valida.E.Erros.Keys)
            {
                Console.WriteLine("Insira novamente "+ campo + ": ");
                campos[campo] = Console.ReadLine();
            }
            return campos;
        }*/
    }
}

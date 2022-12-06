using Nancy.Extensions;
using Nancy.Json;
using Nancy.ViewEngines;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Q1
{
    internal class Controller   
    {

        //ler dados do cliente arquivo JSON
        public static List<ClienteAuxiliar>? LerDados()
        {
            //lendo dados do arquivo JSON
            String? dados = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory
                                          + @"\clientes.json");
            
            //retornando lista de clientesJson
            return JsonConvert.DeserializeObject<List<ClienteAuxiliar>>(dados);
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
            List<ClienteAuxiliar> clienteJson = LerDados();

            //criando lista de erro 
            List<Erro> erros = new();
            Valida? valida;

            //valida dados do arquivo
            foreach (ClienteAuxiliar cliente in clienteJson){
                valida = new(cliente.nome,
                                cliente.cpf,
                                cliente.dt_nascimento,
                                cliente.renda_mensal,
                                cliente.estado_civil,
                                cliente.dependentes);
               
                //se existe erros nos dadosdo arquivo adiciona na lista
                if (!Equals(valida.Erros, null))
                    erros.Add(valida.Erros);              
            }
            //gravando erros em um arquivo
            GravaErros(erros);            
        }            
        
        public static ClienteAuxiliar? LerConsole()
        {
            ClienteAuxiliar? clienteAuxiliar = new ClienteAuxiliar();
            Console.WriteLine("Insira seus dados");
            Console.WriteLine("Nome (pelo menos 5 caracteres): ");
            clienteAuxiliar.nome = Console.ReadLine();

            Console.WriteLine("Cpf (11 digitos): ");
            clienteAuxiliar.cpf = Console.ReadLine();

            Console.WriteLine("Data de Nascimento (não pode ser menor que 18 anos): ");
            clienteAuxiliar.dt_nascimento = Console.ReadLine();

            Console.WriteLine("Renda (maior que 0 e com 2 casa decimais): ");
            clienteAuxiliar.renda_mensal = Console.ReadLine();

            Console.WriteLine(
                "\nC - Casado" +
                "\nS - Solteiro" +
                "\nV - Viuvo" +
                "\nD - Divorciado\n" +
                "\nEstado civil: ");
            clienteAuxiliar.estado_civil = Console.ReadLine();

            Console.WriteLine("Dependentes (entre 0 e 10): ");
            clienteAuxiliar.dependentes = Console.ReadLine();


            return clienteAuxiliar;
        }

        public static void AddComConsole(ClienteAuxiliar cli)
        {
            ClienteAuxiliar dados = cli;
            Console.WriteLine();
            Valida? valida = new(dados.nome, dados.cpf, dados.dt_nascimento, dados.renda_mensal,
                    dados.estado_civil, dados.dependentes); ;

            while (!Equals(valida.Erros, null)){
                ImprimeErros(valida.Erros);
                dados = LerNovamente(valida.Erros, dados);

                valida = new(dados.nome, dados.cpf, dados.dt_nascimento, dados.renda_mensal, 
                    dados.estado_civil, dados.dependentes);
   
            }

            //criando objeto cliente com valores válidos
            Cliente? cliente = new(dados.nome, long.Parse(dados.cpf), 
                                  DateTime.Parse(dados.dt_nascimento),
                                  float.Parse(dados.renda_mensal), 
                                  char.Parse(dados.estado_civil.ToUpper()),
                                  int.Parse(dados.dependentes));
            //Imprimindo dados
            Console.WriteLine(cliente.ToString());
        }

        public static ClienteAuxiliar LerNovamente(Erro erro, ClienteAuxiliar clienteAux)
        {
            //ler novamente somente os dados que foram invalidados
            foreach (string campo in erro.Erros.Keys)
            {
                Console.WriteLine("Insira novamente "+ campo + ": ");
                string valor =  Console.ReadLine();

                //atualizando valida.E.Dados para o valor que foi inserido acima
                //se campo (uma chave de valida.E.Erros) tem o valor igual ao nome
                //da propiedade valida.E.Dados a propriedade recebe o dado lido
                Console.WriteLine(campo, nameof(clienteAux.nome));

                switch (campo)
                {
                    case nameof(clienteAux.nome):
                        clienteAux.nome = valor; break;
                    case nameof(clienteAux.cpf):
                        clienteAux.cpf = valor; break;
                    case nameof(clienteAux.dt_nascimento):
                        clienteAux.dt_nascimento = valor; break;
                    case nameof(clienteAux.renda_mensal):
                        clienteAux.renda_mensal = valor; break;
                    case nameof(clienteAux.estado_civil):
                        clienteAux.estado_civil = valor; break;
                    case nameof(clienteAux.dependentes):
                        clienteAux.dependentes = valor; break;
                }
            }
            return clienteAux;
        }

        public static void ImprimeErros (Erro erro)
        {
            IDictionaryEnumerator? erros = erro.Erros.GetEnumerator();

            //imprime erros na inserção de dados
            while (erros.MoveNext())
            {
                Console.WriteLine(erros.Key + ": " + erros.Value);
            }

            Console.WriteLine();
        }
    }
}

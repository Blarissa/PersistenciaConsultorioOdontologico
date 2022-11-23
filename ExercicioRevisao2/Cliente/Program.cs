

using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ValidaCliente
{
    internal class Program
    {
        public static void CampoNulo(List<String> dados)
        {
            ValidaCliente valida = new ValidaCliente();
            
            if (!valida.Nome(dados[0]))
            {
                Console.WriteLine("\nCampo inválido: " + nameof(dados[0])
                                + "\nValor: " + dados[0]
                                + "\nNome deve ter pelo menos 5 caracteres!");
            }
            
        }
        static void Main()
        {
            
            ValidaCliente valida = new ValidaCliente();
            List<String> dados = new List<String>();

            Console.WriteLine("Insira seus dados");
            Console.WriteLine("Nome (pelo menos 5 caracteres): ");
            dados.Add(Console.ReadLine());

            Console.WriteLine("CPF (somente dígitos e 11 dígitos): ");
            dados.Add(Console.ReadLine());

            Console.WriteLine("Data de Nascimento (no formato 00/00/0000): ");
            dados.Add(Console.ReadLine());

            Console.WriteLine("Renda Mensal (no formato 00,00): ");
            dados.Add(Console.ReadLine());

            Console.WriteLine("Estado Civil (C, S, V ou D): ");
            dados.Add(Console.ReadLine());

            Console.WriteLine("Número de Dependentes (de 0 a 10): ");
            dados.Add(Console.ReadLine());

            

            while(CampoNulo(dados))
            {
                if (String.IsNullOrEmpty(cliente.Nome))
                {
                    Console.WriteLine("Insira seu nome (pelo menos 5 caracteres): ");
                    nome = Console.ReadLine();
                }
                else if (String.IsNullOrEmpty(cliente.Cpf.ToString())) {
                    Console.WriteLine("Insira seu CPF (somente dígitos e 11 dígitos): ");
                    cpf = Console.ReadLine();
                }
                else if (String.IsNullOrEmpty(cliente.DataNascimento.ToString()))
                {
                    Console.WriteLine("Insira sua data de Nascimento (no formato 00/00/0000): ");
                    data = Console.ReadLine();

                }
                else if (String.IsNullOrEmpty(cliente.Renda.ToString()))
                {
                    Console.WriteLine("Renda Mensal (no formato 00,00): ");
                    renda = Console.ReadLine();
                }
                else if (String.IsNullOrEmpty(cliente.EstadoCivil.ToString()))
                {
                    Console.WriteLine("Estado Civil (C, S, V ou D): ");
                    estado = Console.ReadLine();
                }
                else if (String.IsNullOrEmpty(cliente.Dependentes.ToString()))
                {
                    Console.WriteLine("Número de Dependentes (de 0 a 10): ");
                    dependentes = Console.ReadLine();
                }

                cliente = new Cliente(nome,
                                          long.Parse(cpf),
                                          DateTime.Parse(data),
                                          float.Parse(renda),
                                          char.Parse(estado),
                                          int.Parse(dependentes));

            }



        }
    }

}
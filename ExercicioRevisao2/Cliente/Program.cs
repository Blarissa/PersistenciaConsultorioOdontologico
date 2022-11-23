

using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ValidaCliente
{
    internal class Program
    {
        public static String Tenta(Object objeto, string dado) {
            try
            {
                objeto = dado;
            }catch(Exception e)
            {   
                Console.WriteLine(e.Message);
            }

            return dado;
        }
        static void Main()
        {
            
            ValidaCliente valida = new ValidaCliente();          
          
            Console.WriteLine("Insira seus dados");
            Console.WriteLine("Nome (pelo menos 5 caracteres): ");
            String nome = Console.ReadLine();

            Console.WriteLine("CPF (somente dígitos e 11 dígitos): ");
            String cpf = Console.ReadLine();

            Console.WriteLine("Data de Nascimento (no formato 00/00/0000): ");
            String data = Console.ReadLine();

            Console.WriteLine("Renda Mensal (no formato 00,00): ");
            String renda = Console.ReadLine();

            Console.WriteLine("Estado Civil (C, S, V ou D): ");
            String estado = Console.ReadLine();

            Console.WriteLine("Número de Dependentes (de 0 a 10): ");
            String dependentes = Console.ReadLine();

           
            


        }
    }

}
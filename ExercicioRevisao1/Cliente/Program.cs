using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Cliente
{
    internal class Program
    {
        static void Main()
        {
            
            Cliente c = new();

            Console.WriteLine("Insira seus dados");
           
            while(true){

                if (String.IsNullOrEmpty(c.Nome))
                {
                    Console.WriteLine("Nome (pelo menos 5 caracteres): ");
                    try
                    {
                        c.Nome = Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    continue;
                }
                else if (c.Cpf.GetHashCode() == 0)
                {
                    Console.WriteLine("CPF (somente dígitos e 11 dígitos): ");
                    try
                    {
                        c.Cpf = long.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    continue;
                }
                else if (c.DataNascimento.GetHashCode() == 0)
                {
                    Console.WriteLine("Data de Nascimento (no formato 00/00/0000): ");
                    try
                    {
                        c.DataNascimento = DateTime.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    continue;
                }
                else if (c.Renda.GetHashCode() == 0) 
                {
                    Console.WriteLine("Renda Mensal (no formato 00,00): ");
                    try
                    {
                        c.Renda = float.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    continue;

                }
                else if (c.EstadoCivil.GetHashCode() == 0)
                {
                    Console.WriteLine("Estado Civil (C, S, V ou D): ");
                    try
                    {
                        c.EstadoCivil = char.Parse(Console.ReadLine().ToUpper());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    continue;

                }
                else if (!c.Dependentes.HasValue)
                {
                    Console.WriteLine("Número de Dependentes (de 0 a 10): ");
                    try
                    {
                        c.Dependentes = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    continue;
                }
                else
                    break;                
            }
         
            Console.WriteLine(c.ToString());        
            
        }
    }
}
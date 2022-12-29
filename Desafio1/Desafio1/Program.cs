using NUnit.Framework;
using System.Globalization;

namespace Desafio1
{
    internal class Program
    {
        static void Main(string[] args)
        {/*
            while (true)
            {
                Menu.Principal();
            }*/

            string hora = DateTime.Now.ToString("HHmm");

            Console.WriteLine(hora);



        }
    }
}
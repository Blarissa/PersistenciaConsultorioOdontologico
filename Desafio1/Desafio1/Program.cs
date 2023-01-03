using NUnit.Framework;
using System.Globalization;

namespace Desafio1
{
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (Menu.Principal() >= 0){
                continue;            
            }
        }
    }
}
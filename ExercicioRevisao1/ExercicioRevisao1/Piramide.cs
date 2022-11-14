using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioRevisao1
{
    internal class Piramide
    {
        public int N { get; set; }

        public Piramide(int n) {
            try
            {
                N = n;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Desenha(){ 
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N - i; j++)
                    Console.Write(" ");
                
                for (int k = 1; k <= i; k++)
                    Console.Write(k);
                
                for (int l = i - 1; l >= 1; l--)
                    Console.Write(l);
                
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}

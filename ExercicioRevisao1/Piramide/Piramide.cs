using System;

namespace Piramide
{
    internal class Piramide
    {
        private int n;
        public int N
        {
            get {
                if (n < 1)
                    throw new ArgumentException("Numero < 1");
                return n; 
            }
            set { 
                n = value;
                if(n < 1)
                    throw new ArgumentException("Numero < 1");
            }
        }

        public Piramide(int num)
        {
            try
            {
                N = num;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Desenha(){ 
            for (int i = 1; i <= n ; i++)
            {
                for (int j = 1; j <= n - i; j++)
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

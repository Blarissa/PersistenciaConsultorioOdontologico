using System.ComponentModel;

namespace ExercicioRevisao1
{
    internal class Program
    {
        static void Main()
        {

            /*TESTANDO FUNCIONALIDADES DAS CLASSES
             * 
             * 
             * Questão 1
            Piramide piramide = new(4);
            Console.WriteLine("Piramide tamanho 4");
            piramide.Desenha();

            piramide = new(6);
            Console.WriteLine("Piramide tamanho 6");
            piramide.Desenha();

            piramide = new(0);
            */

            /*
             * Questão 2

            Vertice v1, v2;

            v1 = new Vertice(1.8,4);
            v2 = new Vertice(2.5,1);

            Console.WriteLine("Distancia de entre ("+ v1.X + ","+ v1.Y +") e " +
                "("+ v2.X + ", "+ v2.Y +"): "+ v1.Distancia(v2));
            
            //movendo vertice 2
            v2 = v2.Move(v1.X, v1.Y);

            Console.WriteLine("Distancia de entre (" + v1.X + "," + v1.Y + ") e " +
                "(" + v2.X + ", " + v2.Y + "): " + v1.Distancia(v2));
            */

            /*Questão 3
             * 
             
            Vertice[] v1 = new Vertice[3];

            v1[0] = new Vertice(1, 1);
            v1[1] = new Vertice(2, 2);
            v1[2] = new Vertice(-2, 2);

            Triangulo t1 = new(v1);

            Console.WriteLine("Triângulo 1"
                + "\nLado 1: " + t1.Lados[0]
                + "\nLado 2: " + t1.Lados[1]
                + "\nLado 3: " + t1.Lados[2]
                + "\nTipo: " + t1.Tipo.ToString()
                + "\nArea: " + t1.Area
                + "\nPerimetro: " + t1.Perimetro
                + "\n") ;

            Vertice[] v2 = new Vertice[3];

            v2[0] = new Vertice(-2, 2);
            v2[1] = new Vertice(-1, 1);
            v2[2] = new Vertice(2, 2);

            Triangulo t2 = new(v2);

            Console.WriteLine("Triângulo 2"
                + "\nLado 1: " + t2.Lados[0]
                + "\nLado 2: " + t2.Lados[1]
                + "\nLado 3: " + t2.Lados[2]
                + "\nTipo: " + t2.Tipo.ToString()
                + "\nArea: " + t2.Area
                + "\nPerimetro: " + t2.Perimetro
                + "\n");

            if(!t1.Diferente(t2))
                Console.WriteLine("Os triângulos são iguais!");
            else
                Console.WriteLine("Os triângulos são diferentes!");
            */

            /*
             * Questão 4
             */
            List<Vertice> v1 = new List<Vertice>();
            v1.Add(new Vertice(1,2));
            v1.Add(new Vertice(2, 2));
            v1.Add(new Vertice(-2, 2));

            List<Vertice> v2 = new List<Vertice>();
            v2.Add(new Vertice(-2, 2));
            v2.Add(new Vertice(-1, 1));
            v2.Add(new Vertice(-2, 1));
            
            Poligono p1 = new(v1);
           
            Console.WriteLine("Poligono 1"
                + "\nLado 1: " + p1.Lados[0]
                + "\nLado 2: " + p1.Lados[1]
                + "\nLado 3: " + p1.Lados[2]
                + "\nN lados: " + p1.Qtd
                + "\nPerimetro: " + p1.Perimetro()
                + "\n");

            Poligono p2 = new(v2);

            v2.Add(new(6, 7));
            p1.Remove(v1[1]);
            
            if(p2.AddVertice(v2.Last()))
                Console.WriteLine("Adicionou um vertice");

            Console.WriteLine("Poligono 2"
                + "\nLado 1: " + p2.Lados[0]
                + "\nLado 2: " + p2.Lados[1]
                + "\nLado 3: " + p2.Lados[2]
                + "\nLado 4: " + p2.Lados[3]
                + "\nPerimetro: " + p2.Perimetro()
                + "\n");

            Console.WriteLine("Poligono 1"
                + "\nLado 1: " + p1.Lados[0]
                + "\nLado 2: " + p1.Lados[1]
                + "\nPerimetro: " + p1.Perimetro()
                + "\n");
        }
    }
}
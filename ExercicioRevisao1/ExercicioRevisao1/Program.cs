namespace ExercicioRevisao1
{
    internal class Program
    {
        static void Main()
        {

            /*
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
             */
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
        }
    }
}
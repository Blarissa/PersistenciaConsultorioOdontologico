namespace ExercicioRevisao1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * Questão 1
            Piramide piramide = new(4);
            Console.WriteLine("Piramide tamanho 4");
            piramide.Desenha();

            piramide = new(6);
            Console.WriteLine("Piramide tamanho 6");
            piramide.Desenha();
            */

            /*
             * Questão 2*/

            Vertice v1, v2;

            v1 = new Vertice(1.8,4);
            v2 = new Vertice(2.5,1);

            Console.WriteLine("Distancia de entre ("+ v1.X + ","+ v1.Y +") e " +
                "("+ v2.X + ", "+ v2.Y +"): "+ v1.Distancia(v2));
            
            //movendo vertice 2
            v2 = v2.Move(v1.X, v1.Y);

            Console.WriteLine("Distancia de entre (" + v1.X + "," + v1.Y + ") e " +
                "(" + v2.X + ", " + v2.Y + "): " + v1.Distancia(v2));
        }
    }
}
namespace ExercicioRevisao1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Piramide piramide = new(4);
            Console.WriteLine("Piramide tamanho 4");
            piramide.Desenha();

            piramide = new(6);
            Console.WriteLine("Piramide tamanho 6");
            piramide.Desenha();


        }
    }
}
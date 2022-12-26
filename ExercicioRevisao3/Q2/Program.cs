namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IndiceRemissivo i = new(@"texto.txt", "");
            string texto = ManipuladorDeArquivo.LerArquivo(i.PathTXT);


            ValidaPalavra v = new();
            v.Epalavra(texto);

        }
    }
}
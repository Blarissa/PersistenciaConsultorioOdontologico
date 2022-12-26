using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    internal class ManipuladorDeArquivo
    {
        public static string LerArquivo(string url)
        {
            return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + url);
        }

        public static void EscreveArquivo(string url, string texto)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + url, texto);
        }
    }
}

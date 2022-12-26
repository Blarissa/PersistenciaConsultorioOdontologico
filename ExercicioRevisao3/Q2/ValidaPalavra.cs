using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Q2
{
    internal class ValidaPalavra
    {
        public void Epalavra(string texto)
        {
            Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", 
                                 RegexOptions.Compiled | RegexOptions.IgnoreCase);
            List<String> a = new();
            // Find matches.
            a = rx.Split(texto).ToList<String>();
            a.Sort();
            
            int i =0;

            foreach(String s in a)
            {
                List<string> iguais = a.FindAll(a => a.Equals(s));


                Console.WriteLine("{0} ({1})",iguais[0], iguais.Count);
                i++;
            }
        }
    }
}

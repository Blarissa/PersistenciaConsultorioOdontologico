using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class Erro 
    {
        public Hashtable Dados { get; private set; }
        public Hashtable Erros { get; private set; }

        public Erro() {
            Dados = new Hashtable();
            Erros = new Hashtable();
        }

        public bool IsNull()
        {
            return Dados.Count.Equals(0) && Erros.Count.Equals(0);
        }
    }
}

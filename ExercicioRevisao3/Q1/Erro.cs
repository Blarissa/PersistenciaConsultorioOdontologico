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
        public ClienteJson Dados { get; private set; }
        public Hashtable Erros { get; private set; }

        public Erro()
        {
            Dados = new ClienteJson();
            Erros = new Hashtable();
        }
    }
}

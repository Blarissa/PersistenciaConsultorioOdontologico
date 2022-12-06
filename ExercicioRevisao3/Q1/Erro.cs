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
        public ClienteAuxiliar Dados { get; private set; }
        public Hashtable Erros { get; private set; }

        public Erro(ClienteAuxiliar clienteAux, Hashtable errosHash)
        {
            Dados = clienteAux;
            Erros = errosHash;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}

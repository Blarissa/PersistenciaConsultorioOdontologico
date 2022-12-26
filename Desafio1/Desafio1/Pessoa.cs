using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class Pessoa
    {
        public String CPF { get; }
        public String Nome { get; }
        public String DtNascimento { get; }

        public Pessoa(string cpf, string nome, string dtNascimento)
        {
            CPF = cpf;
            Nome = nome;
            DtNascimento = dtNascimento;
        }
    }
}

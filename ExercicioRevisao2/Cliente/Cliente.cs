using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCliente
{
    internal class Cliente
    {
        private string nome;
        private long cpf;
        private DateTime dataNascimento;
        private float renda;
        private char estadoCivil;
        private int? dependentes;

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                if (value.Length >= 5)
                    nome = value;
                else
                    throw new ArgumentException("\nNome precisa ter pelo menos 5 caracteres!");
            }

        }
        public long Cpf
        {
            get
            {
                return cpf;
            }
            set
            {

                int tamanho = value.ToString().Length;

                if (tamanho == 11 || tamanho == 10)
                    cpf = value;
                else
                    throw new ArgumentException("\nCPF com tamanho inválido!");
            }

        }
        public DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            set
            {
                int dias = DateTime.Now.Subtract(dataNascimento).Days;

                if (dias / 365 >= 18)
                    dataNascimento = value;
                else
                    throw new ArgumentException("\nMenor de 18 anos!");
            }
        }
        public float Renda
        {
            get
            {
                return renda;
            }
            set
            {
                //retorna true se tiver virgula no numero
                bool virgula = value.ToString().Contains(",");
                //retorna true se tiver 2 casas decimais
                bool casas = value.ToString().Split(",").Length == 2;

                if (virgula && casas)
                    renda = value;
                else
                    throw new ArgumentException("\nValor diferente do exigido!");
            }
        }
        public char EstadoCivil
        {
            get
            {
                return estadoCivil;
            }
            set
            {
                string valores = "CSVD";

                if (valores.Contains(value))
                    estadoCivil = value;
                else
                    throw new ArgumentException("\nEstado civil inválido!");

            }
        }
        public int? Dependentes
        {
            get
            {
                return dependentes;
            }
            set
            {
                if (value >= 0 && value <= 10)
                    dependentes = value;
                else
                    throw new ArgumentException("\nNumero de dependentes inválidos!");
            }
        }

        public Cliente() { }

        public Cliente(string nome, long cpf, DateTime dataNascimento,
            float renda, char estadoCivil, int? dependentes)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.dataNascimento = dataNascimento;
            this.renda = renda;
            this.estadoCivil = estadoCivil;
            this.dependentes = dependentes;

        }

        public override string ToString()
        {
            string imprime = "\n------------Cliente------------" +
                 "\nNome: " + Nome
               + "\nCPF: " + Cpf
               + "\nData de nascimento: " + DataNascimento.ToString("dd/MM/yyyy")
               + "\nRenda Mensal: " + Renda.ToString("C", NumberFormatInfo.CurrentInfo)
               + "\nEstado Civil: " + EstadoCivil
               + "\nNumero de Dependente: " + Dependentes
               + "\n";

            return imprime;
        }
    }
}

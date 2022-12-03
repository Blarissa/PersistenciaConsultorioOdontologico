using System;
using System.Globalization;

namespace Q1
{
    internal class Cliente
    {
        public String Nome { get; private set; }
        public long Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public float Renda { get; private set; }
        public char EstadoCivil { get; private set; }
        public int Dependentes { get; private set; }

        public Cliente(string nome, long cpf, DateTime dataNascimento, float renda, char estadoCivil, int dependentes)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Renda = renda;
            EstadoCivil = estadoCivil;
            Dependentes = dependentes;
        }

        public override string ToString()
        {
            return "\n------------Cliente------------" 
                 + "\nNome: " + Nome
                 + "\nCPF: " + Cpf
                 + "\nData de nascimento: " + DataNascimento.ToString("dd/MM/yyyy")
                 + "\nRenda Mensal: " + Renda.ToString("C", NumberFormatInfo.CurrentInfo)
                 + "\nEstado Civil: " + EstadoCivil
                 + "\nNumero de Dependente: " + Dependentes
                 + "\n";
        }
    }
}

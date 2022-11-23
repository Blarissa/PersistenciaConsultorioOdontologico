using System;
using System.Globalization;

namespace ValidaCliente
{
    internal class Cliente
    {
        private string nome;
        private long cpf;
        private DateTime dataNascimento;
        private float renda;
        private char estadoCivil;
        private int dependentes;

        private ValidaCliente valida = new();

        public string Nome
        {
            get
            {
                return nome;
            }
            private set
            {
                if (valida.Nome(value))
                    nome = value;
                else
                    throw new ArgumentException("\nCampo inválido: " + nameof(value)
                                             + "\nValor: " + value
                                              + "\nNome deve ter pelo menos 5 caracteres!");
            }

        }
        public long Cpf
        {
            get
            {
                return cpf;
            }
            private set
            {
                if (valida.CPF(value))
                    cpf = value;
                else
                    throw new ArgumentException("\nCampo inválido: " + nameof(value)
                                              + "\nValor: " + value
                                              + "\nCPF com tamanho diferente de 11!");
            }

        }
        public DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            private set
            {
                if (valida.DataDeNascimento(value))
                    dataNascimento = value;
                else
                    throw new ArgumentException("\nCampo inválido: " + nameof(dataNascimento)
                                              + "\nValor: " + dataNascimento
                                              + "\nMenor de 18 anos!");
            }
        }
        public float Renda
        {
            get
            {
                return renda;
            }
            private set
            {
                if (valida.Renda(value))
                    renda = value;
                else
                    throw new ArgumentException("\nCampo inválido: " + nameof(renda)
                                              + "\nValor: " + renda
                                              + "\nValor diferente do exigido!");
            }
        }
        public char EstadoCivil
        {
            get
            {
                return estadoCivil;
            }
            private set
            {
                if (valida.EstadoCivil(value))
                    estadoCivil = value;
                else
                    throw new ArgumentException("\nCampo inválido: " + nameof(value)
                                              + "\nValor: " + value);
            }
        }
        public int Dependentes
        {
            get
            {
                return dependentes;
            }
            private set
            {
                if (valida.Dependentes(value))
                    dependentes = value;
                else
                    throw new ArgumentException("\nCampo inválido: " + nameof(value)
                                              + "\nValor: " + value
                                              + "\nNumero de dependentes deve ser entre 0 e 10!");
            }
        }

        

        public Cliente(string nome, long cpf, DateTime data, float renda,
            char estadoCivil, int dependentes)
        {
            try
            {
                this.nome = nome;
            } catch (Exception) {
                throw;
            }

            try
            {
                this.cpf = cpf;
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                this.dataNascimento = data;
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                this.renda = renda;
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                this.estadoCivil = estadoCivil;
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                this.dependentes = dependentes;
            }
            catch (Exception)
            {

                throw;
            }
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

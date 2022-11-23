using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    internal class ValidaCliente
    {
        public Cliente Cliente { get; set; }

        public bool Nome(string nome)
        {
            return nome.Length >= 5;
        }

        public bool CPF(string cpf)
        {
            if (cpf.Length == 11)
            {
                if (cpf.All(c=> cpf[0] == c))
                    return false;
 
                int soma = 0;
                int i = 0;
                for (int j = 10; j >= 2; j--, i++)        
                    soma += (int)Char.GetNumericValue(cpf[i]) * j;
                
                int resto = soma % 11;
                
                bool J = false;
                bool K = false;

                if (resto == 0 || resto == 1)
                    J = (int) Char.GetNumericValue(cpf[9]) == 0;
                else if (resto >= 2 && resto <= 10)
                    J = (int) Char.GetNumericValue(cpf[9]) == (11 - resto);

                soma = 0;
                i = 0;

                for (int j = 11; j >= 2 ; j--,i++)
                    soma += (int)Char.GetNumericValue(cpf[i]) * j;

                resto = soma % 11;

                if (resto == 0 || resto == 1)
                    K = (int) Char.GetNumericValue(cpf[10]) == 0;
                else if (resto >= 2 && resto <= 10)
                    K = (int)Char.GetNumericValue(cpf[10]) == (11 - resto);

                return J && K;
            }         

            return false;
        }
        public bool DataDeNascimento(string dataNascimento)
        {
            DateTime data = DateTime.Parse(dataNascimento);

            return (DateTime.Now.Subtract(data).Days / 365) >= 18;
        }        
        public bool Renda(String renda)
        {   
            float valor = float.Parse(renda);
            bool formato = valor.ToString("F").Equals(renda);         
               
            return (valor > 0 && formato);
        }
        public bool EstadoCivil(string estadoCivil)
        {
            char[] estado = {'C','S','V','D'};

            return estado.Contains(char.Parse(estadoCivil));
        }
        public bool Dependentes(string dependentes)
        {
            int valor = int.Parse(dependentes);
            return valor >= 0 && valor <= 10;

        }
    }
}

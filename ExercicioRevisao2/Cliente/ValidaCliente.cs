using System;
namespace ValidaCliente
{
    internal class ValidaCliente
    {
        public ValidaCliente() { }

        public bool Nome(string nome)
        {
            return nome.Length >= 5;
        }

        public bool CPF(long cpf)
        {
            if (cpf.ToString().Length == 11){
                if (cpf.ToString().All(c => cpf.ToString()[0] == c))
                    return false;
 
                int soma = 0;
                int i = 0;
                for (int j = 10; j >= 2; j--, i++)        
                    soma += (int)Char.GetNumericValue(cpf.ToString()[i]) * j;
                
                int resto = soma % 11;
                bool J = false;
                bool K = false;

                if (resto == 0 || resto == 1)
                    J = (int) Char.GetNumericValue(cpf.ToString()[9]) == 0;
                else if (resto >= 2 && resto <= 10)
                    J = (int) Char.GetNumericValue(cpf.ToString()[9]) == (11 - resto);

                soma = 0;
                i = 0;

                for (int j = 11; j >= 2 ; j--,i++)
                    soma += (int)Char.GetNumericValue(cpf.ToString()[i]) * j;

                resto = soma % 11;

                if (resto == 0 || resto == 1)
                    K = (int) Char.GetNumericValue(cpf.ToString()[10]) == 0;
                else if (resto >= 2 && resto <= 10)
                    K = (int)Char.GetNumericValue(cpf.ToString()[10]) == (11 - resto);

                return J && K;
            }         

            return false;
        }
        public bool DataDeNascimento(DateTime dataNascimento)
        { 
            return (DateTime.Now.Subtract(dataNascimento).Days / 365) >= 18;
        }        
        public bool Renda(float renda)
        {   
            bool formato = renda.ToString("F").Equals(renda.ToString());         
               
            return (renda > 0 && formato);
        }
        public bool EstadoCivil(char estadoCivil)
        {
            return estadoCivil == 'C' || 
                   estadoCivil == 'S' ||
                   estadoCivil == 'V'|| 
                   estadoCivil == 'D';
        }

        public bool Dependentes(int dependentes)
        {
            return dependentes >= 0 && dependentes <= 10;
        }
    }
}

using System;
using System.Collections;
using System.Globalization;

namespace Q1

{
    internal class Valida
    {
        public String Nome { get; private set; }
        public long Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public float Renda { get; private set; }
        public char EstadoCivil { get; private set; }
        public int Dependentes { get; private set; }
        public Erro E { get; private set; }

        public Valida(string nome, string cpf, string dt_nascimento,
            string renda_mensal, string estado_civil, string dependentes)
        {
            E = new Erro();

            if (ValidaNome(nome))
                Nome = nome;
            else
                E.Erros.Add("Nome", "Deve ter pelo menos 5 caracteres!");

            if (ValidaCPF(long.Parse(cpf)))
                Cpf = long.Parse(cpf);
            else
                E.Erros.Add("CPF", "Deve ter 11 dígitos e ser válido!");

            
            if (ValidaDataDeNascimento(dt_nascimento))
                DataNascimento = Convert.ToDateTime(dt_nascimento);
            else
                E.Erros.Add("Data de Nascimento", "Não pode ter menos que 18 anos!");
            
            if (ValidaRenda(float.Parse(renda_mensal)))
                Renda = float.Parse(renda_mensal);
            else                
                E.Erros.Add("Renda mensal",
                    "Deve ser maior que 0 e conter 2 casas decimais com virgula!");            

            if (ValidaEstadoCivil(char.Parse(estado_civil.ToUpper())))
                EstadoCivil = char.Parse(estado_civil.ToUpper());
            else               
                E.Erros.Add("Estado civil",
                    "Deve ser C(casado), S(solteiro), V(viúvo) ou D(divorciado)!");            

            if (ValidaDependentes(int.Parse(dependentes)))
                Dependentes = int.Parse(dependentes);
            else
                E.Erros.Add("Dependentes",
                    "Deve estar entre 0 e 10!");          

            if(E.Erros.Count > 0)
            {
                E.Dados.Add(nameof(nome), nome);
                E.Dados.Add(nameof(cpf), cpf);
                E.Dados.Add(nameof(dt_nascimento), dt_nascimento);
                E.Dados.Add(nameof(renda_mensal), renda_mensal);
                E.Dados.Add(nameof(estado_civil), estado_civil.ToUpper());
                E.Dados.Add(nameof(dependentes), dependentes);
            }
        }

        public static bool ValidaNome(string nome)
        {
            return nome.Length >= 5;
        }
        public static bool ValidaCPF(long cpf)
        {
            if (cpf.ToString().Length == 11)
            {
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
                    J = (int)Char.GetNumericValue(cpf.ToString()[9]) == 0;
                else if (resto >= 2 && resto <= 10)
                    J = (int)Char.GetNumericValue(cpf.ToString()[9]) == (11 - resto);

                soma = 0;
                i = 0;

                for (int j = 11; j >= 2; j--, i++)
                    soma += (int)Char.GetNumericValue(cpf.ToString()[i]) * j;

                resto = soma % 11;

                if (resto == 0 || resto == 1)
                    K = (int)Char.GetNumericValue(cpf.ToString()[10]) == 0;
                else if (resto >= 2 && resto <= 10)
                    K = (int)Char.GetNumericValue(cpf.ToString()[10]) == (11 - resto);

                return J && K;
            }

            return false;
        }
        public static bool ValidaDataDeNascimento(String dataNascimento)
        {
            DateTime data;
            return DateTime.TryParse(dataNascimento, out data) && 
                (DateTime.Now.Subtract(data).Days/ 365) >= 18;
        }
        public static bool ValidaRenda(float renda)
        {
            bool formato = renda.ToString("F").Equals(renda.ToString());

            return (renda > 0 && formato);
        }
        public static bool ValidaEstadoCivil(char estadoCivil)
        {
            return estadoCivil == 'C' ||
                   estadoCivil == 'S' ||
                   estadoCivil == 'V' ||
                   estadoCivil == 'D';
        }
        public static bool ValidaDependentes(int dependentes)
        {
            return dependentes >= 0 && dependentes <= 10;
        }  
    }
}

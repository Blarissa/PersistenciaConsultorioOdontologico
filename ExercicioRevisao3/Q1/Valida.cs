using System;
using System.Collections;
using System.ComponentModel;

namespace Q1

{
    internal class Valida
    {
        public Erro Erros { get; private set; }

        public Valida(string nome, string cpf, string dt_nascimento, string renda_mensal,
                      string estado_civil, string dependentes){

            Hashtable erros = new ();
            
            //validando dados
            if (!ValidaNome(nome))
                erros.Add("nome", 
                    "Deve ter pelo menos 5 caracteres!");

            if (!ValidaCPF(cpf))
               erros.Add("cpf",
                    "CPF inválido");
            
            if (!ValidaDataDeNascimento(dt_nascimento))              
               erros.Add("dt_nascimento",
                    "Data de nascimento inválida");

            if (!ValidaRenda(renda_mensal))                               
                erros.Add("renda_mensal",
                    "Renda mensal inválida");            

            if (!ValidaEstadoCivil(estado_civil.ToUpper()))               
                erros.Add("estado_civil",
                    "Estado civil inválido");            

            if (!ValidaDependentes(dependentes))               
                erros.Add("dependentes",
                    "Número de dependentes inválido");

            if (!Equals(erros, null))
            {
                ClienteAuxiliar clienteAux = new ClienteAuxiliar();

                clienteAux.nome = nome;
                clienteAux.cpf = cpf;
                clienteAux.renda_mensal = renda_mensal;
                clienteAux.dt_nascimento = dt_nascimento;
                clienteAux.estado_civil = estado_civil.ToUpper();
                clienteAux.dependentes = dependentes;

                Erros = new Erro(clienteAux, erros);
            }
        }
        
        //validações dos dados
        public static bool ValidaNome(string nome)
        {
            return nome.Length >= 5;
        }
        public static bool ValidaCPF(string cpf)
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
        public static bool ValidaDataDeNascimento(string dataNascimento)
        {
            
            return DateTime.TryParse(dataNascimento, out DateTime dt) && 
                   DateTime.Now.Subtract(dt).Days/ 365 >= 18;
        }
        public static bool ValidaRenda(string renda)
        {
            float.TryParse(renda, out float val);
            bool formato = val.ToString("F").Equals(renda);

            return (val > 0 && formato);
        }
        public static bool ValidaEstadoCivil(string estadoCivil)
        {
            char.TryParse(estadoCivil, out char val);

            return val == 'C' ||
                   val == 'S' ||
                   val == 'V' ||
                   val == 'D';
        }
        public static bool ValidaDependentes(string dependentes)
        {
            int.TryParse(dependentes, out int val);
            return val >= 0 && val <= 10;
        }  
    }
}

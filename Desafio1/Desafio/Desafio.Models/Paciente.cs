﻿namespace Desafio.Desafio.Models
{
    /// <summary>
    /// Define um <see cref="Paciente"/> de um consultório odontológico.
    /// </summary>
    public class Paciente
    {
        public long CPF { get; private set; }
        public string Nome { get; private set; }
        public DateTime DtNascimento { get; private set; }
        public int Idade { get => DateTime.Now.Subtract(DtNascimento).Days / 365; }

        /// <summary>
        /// Cria uma instância de <see cref="Paciente"/> com os argumentos utilizados.
        /// </summary>
        ///<param name = "CPF">Representa o valor da propriedade <see cref="CPF"/>, deve possuir o valor de um <see cref="CPF"/> válido e não existir outro <see cref="Paciente"> com o mesmo <see cref="CPF">.</param>
        ///<param name = "Nome">Representa o valor da propriedade <paramref name="Nome"/>, deve possuir pelo menos 5 caracteres. </param>
        ///<param name = "DtNascimento">Representa o valor da propriedade <paramref name="DtNascimento"/>, deve possuir o formato DD/MM/AAAA e o <see cref="Paciente"> deve ter 13 anos ou mais no momento do cadastro(<see cref="DateTime.Now">).</param>        
        public Paciente(long CPF, string Nome, DateTime DtNascimento)
        {
            this.CPF = CPF;
            this.Nome = Nome;
            this.DtNascimento = DtNascimento;
        }
    }
}

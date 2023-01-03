namespace Desafio1
{
    internal class Paciente
    {
        public long CPF { get; private set; }
        public string Nome { get; private set; }
        public DateTime DtNascimento { get; private set; }
        public int Idade { get => DateTime.Now.Subtract(DtNascimento).Days / 365; }

        public Paciente(long CPF, string Nome, DateTime DtNascimento)
        {
            this.CPF = CPF;
            this.Nome = Nome;
            this.DtNascimento = DtNascimento;
        }
    }
}

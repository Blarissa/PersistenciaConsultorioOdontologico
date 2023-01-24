using Desafio.Desafio.Models;
using Desafio.Desafio.View;

namespace Desafio.Desafio.Controllers
{
    public class PacienteController
    {
        public List<Paciente> Pacientes = new();        

        //Adionando paciente
        public void Adiciona()
        {
            long CPF = EntradaDeDados.LerCPF();
            if (PacienteExiste(CPF))
            {
                Console.WriteLine(Menssagens.CpfExistente);
                CPF = EntradaDeDados.LerCPF();
            }

            string nome = EntradaDeDados.LerNome();
            DateTime dtNasc = EntradaDeDados.LerDtNascimento();

            Pacientes.Add(new(CPF, nome, dtNasc));
            Console.WriteLine(Menssagens.PacienteCadastrado);
        }

        //Retorna o paciente de determinado CPF 
        public Paciente? PesquisaCPF(long CPF)
        {
            if (PacienteExiste(CPF))
                return Pacientes.Find(paciente => paciente.CPF.Equals(CPF));

            return null;
        }

        

        //Removendo paciente
        public void Remove()
        {
            long CPF = EntradaDeDados.LerCPF();

            //Se não encontrar o paciente na lista imprime a mensagem de erro
            while (!PacienteExiste(CPF))
            {
                Console.WriteLine(Menssagens.PacienteInixistente);
                CPF = EntradaDeDados.LerCPF();
            }

            List<Consulta> consultas = new Agenda().PesquisaConsultasPorCPF(CPF);

            if (consultas.Exists(c => c.DtConsulta >= DateTime.Now))
                Console.WriteLine(Menssagens.PacienteAgendado);

            else if (consultas.Count >= 1)
            {
                //removendo consultas
                new Agenda().Consultas.RemoveAll(c => c.CPF.Equals(CPF));
                //removendo paciente
                Pacientes.Remove(PesquisaCPF(CPF));
                Console.WriteLine(Menssagens.PacienteExcluido);
            }
        }

        public override string? ToString()
        {
            string str = "".PadRight(60, '-') + "\n"
                       + $"{"CPF",-11} {"Nome",-33} {"Dt.Nasc."} {"Idade"}\n"
                       + "".PadRight(60, '-') + "\n";

            Pacientes.ForEach(p =>
            {
                str += $"{p.CPF, -11:00000000000} {p.Nome,-33} " +
                       $"{p.DtNascimento.ToShortDateString()} {p.Idade}\n";

                List<Consulta> consultas = new Agenda().PesquisaConsultasPorCPF(p.CPF);

                if (consultas.Exists(c => c.DtConsulta >= DateTime.Now))
                    consultas.ForEach(c => str += $"{"",-11} " +
                           $"Agendado para: {c.DtConsulta:d}\n" +
                           $"{"",-11} {c.HrInicial:t} às {c.HrFinal:t}\n");
            });
            return str;
        }

        public bool PacienteExiste(long cpf)
        {
            return Pacientes.Exists(p => p.CPF.Equals(cpf));
        }

        //Listar pacientes(ordenado por nome)
        public string? PacientesOrdemNome()
        {
            Pacientes = Pacientes.OrderBy(p => p.Nome).ToList();

            return ToString();
        }

        //Listar pacientes(ordenado por CPF)
        public string? PacientesOrdemCPF()
        {
            Pacientes = Pacientes.OrderBy(p => p.CPF).ToList();
            return ToString();
        }

    }
}

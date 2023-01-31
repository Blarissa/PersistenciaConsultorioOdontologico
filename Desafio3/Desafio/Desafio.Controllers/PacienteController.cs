using Desafio.Dasafio.Dados;
using Desafio.Desafio.Models;
using Desafio.Desafio.View;

namespace Desafio.Desafio.Controllers
{
    public class PacienteController
    {
        PacienteDAO DBConnection = new PacienteDAO();
        //Adionando paciente
        public void Adiciona()
        {
            long CPF = EntradaDeDados.LerCPF();
            if (new Valida().PacienteExiste(CPF))
            {
                Console.WriteLine(Menssagens.CpfExistente);
                CPF = EntradaDeDados.LerCPF();
            }

            string nome = EntradaDeDados.LerNome();
            DateTime dtNasc = EntradaDeDados.LerDtNascimento();

            DBConnection.AdicionarPaciente(CPF, nome, dtNasc);
        }        

        //Removendo paciente
        public void Remove()
        {
            long CPF = EntradaDeDados.LerCPF();

            //Se não encontrar o paciente na lista imprime a mensagem de erro
            while (!new Valida().PacienteExiste(CPF))
            {
                Console.WriteLine(Menssagens.PacienteInixistente);
                CPF = EntradaDeDados.LerCPF();
            }

            List<Consulta> consultas = new Agenda().PesquisaConsultasPorCPF(CPF);

            if (consultas.Exists(c => c.DataHoraInicial >= DateTime.Now))
                Console.WriteLine(Menssagens.PacienteAgendado);

            else if (consultas.Count >= 1)
            {
                //removendo consultas
                new Agenda().Consultas.RemoveAll(c => c.Paciente.Equals(new Paciente(CPF, "", new DateTime(0001,01,01))));
                //removendo paciente
                DBConnection.RemoverPaciente(CPF);
                Console.WriteLine(Menssagens.PacienteExcluido);
            }
        }

        private string? FormatarSaida(List<Paciente> list)
        {
            string str = "".PadRight(60, '-') + "\n"
                       + $"{"CPF",-11} {"Nome",-33} {"Dt.Nasc."} {"Idade"}\n"
                       + "".PadRight(60, '-') + "\n";

            list.ForEach(p => {
                str += $"{p.CPF,-11:00000000000} {p.Nome,-33} " +
                       $"{p.DtNascimento.ToShortDateString()} {p.Idade}\n";

                List<Consulta> consultas = new Agenda().PesquisaConsultasPorCPF(p.CPF);

                if (consultas.Exists(c => c.DataHoraInicial >= DateTime.Now))
                    consultas.ForEach(c => str += $"{"",-11} " +
                           $"Agendado para: {c.DataHoraInicial.Date:d}\n" +
                           $"{"",-11} {c.DataHoraInicial:t} às {c.DataHoraFinal:t}\n");
            });
            return str;
        }


        //Listar pacientes(ordenado por nome)
        public string? PacientesOrdemNome()
        {
            List<Paciente> pacientes = DBConnection.TodosPacientes().OrderBy(p => p.Nome).ToList();
            return FormatarSaida(pacientes);
        }

        //Listar pacientes(ordenado por CPF)
        public string? PacientesOrdemCPF()
        {
            List<Paciente> pacientes = DBConnection.TodosPacientes().OrderBy(p => p.CPF).ToList();
            return FormatarSaida(pacientes);
        }

    }
}

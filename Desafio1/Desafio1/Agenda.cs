using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class Agenda
    {
        public List<Consulta> Consultas = new();
        public List<DateTime> Agendamentos= new();

        //Agendando nova consulta
        public void Agendar() {

            long CPF = EntradaDeDados.LerCPF();
            DateTime data = EntradaDeDados.LerDtConsulta();
            DateTime hrInicial = EntradaDeDados.LerHrInicial();
            DateTime hrFinal = EntradaDeDados.LerHrFinal(hrInicial.TimeOfDay.ToString("HHmm"));

            Consultas.Add(new Consulta (CPF, data, hrInicial, hrFinal));
            Console.WriteLine(Menssagens.AgendamentoRealizado);
        }

        //Pesquisa consulta
        public Consulta? PesquisaConsulta(long CPF, DateTime dtConsulta, DateTime hrInicial) {
            if(ConsultaExiste(CPF, dtConsulta, hrInicial)) 
                return Consultas.Find(consulta => consulta.CPF.Equals(CPF) &&
                       consulta.DtConsulta.Date.Equals(dtConsulta.Date) &&
                       consulta.HrInicial.TimeOfDay.Equals(hrInicial.TimeOfDay));
            return null;
        }

        //Pesquisa consultas por período
        public List<Consulta> PesquisaConsultasPeriodo(DateTime dtInicial, DateTime dtFinal){
            return Consultas.FindAll(consulta => 
                consulta.DtConsulta >= dtInicial && consulta.DtConsulta <= dtFinal);
        }

        //Retorna se a consulta existe
        public bool ConsultaExiste(long CPF, DateTime dtConsulta, DateTime hrInicial)
        {
            return Consultas.Exists(consulta => consulta.CPF.Equals(CPF) &&
                                    consulta.DtConsulta.Date.Equals(dtConsulta.Date) &&
                                    consulta.HrInicial.TimeOfDay.Equals(hrInicial.TimeOfDay));
        }
        
        //Cancelando consulta
        public void Cancelar()
        {
            long CPF = EntradaDeDados.LerCPF();
            DateTime dtConsulta = EntradaDeDados.LerDtConsulta(); 
            DateTime hrInicial = EntradaDeDados.LerHrInicial();

            while (!ConsultaExiste(CPF, dtConsulta, hrInicial))
            {
                Console.WriteLine(Menssagens.AgendInexistente);
                CPF = EntradaDeDados.LerCPF();
                dtConsulta = EntradaDeDados.LerDtConsulta();
                hrInicial = EntradaDeDados.LerHrInicial();
            }

            Consultas.Remove(PesquisaConsulta(CPF, dtConsulta, hrInicial));
            Console.WriteLine(Menssagens.AgendamentoCancelado);
        }
       
        public override string? ToString()
        {
            string str = ("").PadRight(61, '-') + "\n" + ("").PadLeft(3) 
                + $"{"Data"} " + ("").PadRight(3) + $"{"H.Ini"} "
                + $"{"H.Fim"} {"Tempo"} {"Nome"} {"Dt.Nasc.",26} \n"
                + ("").PadRight(61, '-') + "\n";

            Consultas.ForEach(c =>{
                Paciente paciente = new PacienteController().PesquisaCPF(c.CPF);

                str += $"{c.DtConsulta.ToShortDateString()} "
                     + $"{c.HrInicial.ToShortTimeString()} "
                     + $"{c.HrFinal.ToShortTimeString()} "
                     + $"{c.Tempo:hh\\:mm} {paciente.Nome} "
                     + $"{paciente.DtNascimento.ToShortDateString()}\n";
            });               

            return str;
        }

        //Listagem da agenda
        public string ListarAgendamentos(){
            char periodo = EntradaDeDados.LerChar();

            if (char.ToUpper(periodo).Equals('P')){
                DateTime inicial = EntradaDeDados.LerDataInicial();
                DateTime final = EntradaDeDados.LerDataFinal();

                string str = $"Data inicial: {inicial.ToShortDateString()}\n"
                           + $"Data final: {final.ToShortDateString()}\n";

                str = ("").PadRight(61, '-') + "\n" + ("").PadLeft(3) 
                    + $"{"Data"} " + ("").PadRight(3) + $"{"H.Ini"} "
                    + $"{"H.Fim"} {"Tempo"} {"Nome"} {"Dt.Nasc.",26} \n"
                    + ("").PadRight(61, '-') + "\n";

                PesquisaConsultasPeriodo(inicial, final).ForEach(c =>{
                    Paciente? paciente = new PacienteController().PesquisaCPF(c.CPF);

                    str += $"{c.DtConsulta.ToShortDateString()} "
                         + $"{c.HrInicial.ToShortTimeString()} "
                         + $"{c.HrFinal.ToShortTimeString()} "
                         + $"{c.Tempo:hh\\:mm} {paciente.Nome} "
                         + $"{paciente.DtNascimento.ToShortDateString()}\n";
                });
                return str;
            }
            else if (char.ToUpper(periodo).Equals('T'))
                return ToString();
            else{
                Console.WriteLine(Menssagens.opcaoInvalida);
                periodo = char.Parse(Console.ReadLine());
                return ListarAgendamentos();
            }            
        }                
    }
}

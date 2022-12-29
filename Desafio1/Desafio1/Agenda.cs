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

        public void Agendar() {

            long CPF = EntradaDeDados.LerCPF();
            DateTime data = EntradaDeDados.LerDtConsulta();
            DateTime hrInicial = EntradaDeDados.LerHrInicial();
            DateTime hrFinal = EntradaDeDados.LerHrFinal(hrInicial.TimeOfDay.ToString("HHmm"));

            Consultas.Add(new Consulta (CPF, data, hrInicial, hrFinal));
            Console.WriteLine(Menssagens.AgendamentoRealizado);
        }

        public Consulta? PesquisaConsulta(long CPF, DateTime dtConsulta, DateTime hrInicial) {
            if(ConsultaExiste(CPF, dtConsulta, hrInicial)) 
                return Consultas.Find(consulta => consulta.CPF.Equals(CPF) &&
                       consulta.DtConsulta.Date.Equals(dtConsulta.Date) &&
                       consulta.HrInicial.TimeOfDay.Equals(hrInicial.TimeOfDay));
            return null;
        }

        public bool ConsultaExiste(long CPF, DateTime dtConsulta, DateTime hrInicial)
        {
            return Consultas.Exists(consulta => consulta.CPF.Equals(CPF) &&
                                    consulta.DtConsulta.Date.Equals(dtConsulta.Date) &&
                                    consulta.HrInicial.TimeOfDay.Equals(hrInicial.TimeOfDay));
        }

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
    
        /*Listagem da agenda
        public string ListarAgendamentos()
        {
            return "";
        }

        public string ListarAgendamentosPeriodo(DateTime dtInicial, DateTime dtFinal)
        {
            return "";
        }
        */
    }
}

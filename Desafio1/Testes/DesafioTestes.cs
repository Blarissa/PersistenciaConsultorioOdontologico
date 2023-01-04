using Desafio.Desafio.Controllers;
using Desafio.Desafio.Models;
using System.Globalization;
namespace Testes
{
    public class DesafioTestes
    {
        [Fact]
        public void AdicionaPacienteCerto()
        {
            var p1 = new Paciente(
                88107612353, "Larissa", DateTime.Parse("21/09/2001"));
            var p2 = new Paciente(
                05956347376, "Larissa", DateTime.Parse("21/09/2001"));

            var controller = new PacienteController();

            //Para adicionar todos os dados devem ser validados
            //CPF
            Assert.True(Valida.ValidaCpf(p1.CPF.ToString($"{0:00000000000}")));
            Assert.False(controller.PacienteExiste(p1.CPF));
            //Nome
            Assert.True(Valida.ValidaNome(p1.Nome));
            //Data de nascimento
            Assert.True(Valida.ValidaDataFormato(p1.DtNascimento.ToShortDateString()));
            Assert.True(Valida.ValidaDataNascimento(p1.DtNascimento.ToShortDateString()));

            //CPF
            Assert.True(Valida.ValidaCpf(p2.CPF.ToString($"{0:00000000000}")));
            Assert.False(controller.PacienteExiste(p2.CPF));
            //Nome
            Assert.True(Valida.ValidaNome(p2.Nome));
            //Data de nascimento
            Assert.True(Valida.ValidaDataFormato(p2.DtNascimento.ToShortDateString()));
            Assert.True(Valida.ValidaDataNascimento(p2.DtNascimento.ToShortDateString()));
        }

        [Fact]
        public void AdicionaPacienteErrado()
        {
            var p1 = new Paciente(
                000, "Larissa", DateTime.Parse("21/09/2015"));
            var p2 = new Paciente(
                29924840089, "Lia", DateTime.Parse("21/09/2001"));
            var p3 = new Paciente(
                29924840089, "Joelma", DateTime.Parse("30/11/1998"));

            var controller = new PacienteController();

            //Para adicionar todos os dados devem ser validados
            //CPF
            Assert.False(Valida.ValidaCpf(p1.CPF.ToString($"{0:00000000000}")));
            Assert.False(controller.PacienteExiste(p1.CPF));
            //Nome
            Assert.True(Valida.ValidaNome(p1.Nome));
            //Data de nascimento
            Assert.True(Valida.ValidaDataFormato(p1.DtNascimento.ToShortDateString()));
            Assert.False(Valida.ValidaDataNascimento(p1.DtNascimento.ToShortDateString()));

            //CPF
            Assert.True(Valida.ValidaCpf(p2.CPF.ToString($"{0:00000000000}")));
            Assert.False(controller.PacienteExiste(p2.CPF));
            //Nome
            Assert.False(Valida.ValidaNome(p2.Nome));
            //Data de nascimento
            Assert.True(Valida.ValidaDataFormato(p2.DtNascimento.ToShortDateString()));
            Assert.True(Valida.ValidaDataNascimento(p2.DtNascimento.ToShortDateString()));

            //CPF
            Assert.True(Valida.ValidaCpf(p3.CPF.ToString($"{0:00000000000}")));
            Assert.False(controller.PacienteExiste(p3.CPF));
            //Nome
            Assert.True(Valida.ValidaNome(p3.Nome));
            //Data de nascimento
            Assert.True(Valida.ValidaDataFormato(p3.DtNascimento.ToShortDateString()));
            Assert.True(Valida.ValidaDataNascimento(p3.DtNascimento.ToShortDateString()));
        }

        [Fact]
        public void RemovePacienteCerto()
        {
            var p1 = new Paciente(
                07275472082, "Larissa", DateTime.Parse("19/02/2003"));

            var controller = new PacienteController();
            var agenda = new Agenda();

            List<Consulta> consultas = agenda.PesquisaConsultasPorCPF(p1.CPF);

            //Não pode existir uma consulta agendada futura para esse paciente
            Assert.False(consultas.Exists(c => c.DtConsulta >= DateTime.Now));
        }

        [Fact]
        public void RemovePacienteErrado()
        {
            var p1 = new Paciente(
                07275472082, "Larissa", DateTime.Parse("19/02/2003"));

            var controller = new PacienteController();
            var agenda = new Agenda();


            CultureInfo pt = new("pt-BR");
            var consulta = new Consulta(
                07275472082, DateTime.Parse("21/09/2023"),
                DateTime.ParseExact("0800", "HHmm", pt),
                DateTime.ParseExact("0815", "HHmm", pt));

            agenda.Consultas.Add(consulta);

            List<Consulta> consultas = agenda.PesquisaConsultasPorCPF(p1.CPF);

            //Não pode existir uma consulta agendada futura para esse paciente
            Assert.True(consultas.Exists(c => c.DtConsulta >= DateTime.Now));
        }
        
        [Fact]
        public void AgendamentoCerto()
        {
            var p1 = new Paciente(
                11449750001, "Pedro", DateTime.Parse("01/04/1980"));

            var p = new PacienteController();
            p.Pacientes.Add(p1);

            //Paciente deve estar na lista de cadastro
            long CPF = 11449750001;
            Assert.True(p.PacienteExiste(CPF));
            
            Assert.True(Valida.ValidaDataFormato("21/09/2023"));

            //todas as datas de agendamento
            var datas = new Agenda().Agendamentos;
            Assert.True(Valida.ValidaDataConsulta(datas, "21/09/2023"));

            CultureInfo pt = new("pt-BR");
            
            Assert.True(Valida.ValidaHoraFormato("0800"));
            Assert.True(Valida.ValidaHrInicial(datas, "0800"));

            Assert.True(Valida.ValidaHoraFormato("0830"));
            Assert.True(Valida.ValidaHrFinal(datas, "0830", "0800"));

            var agenda = new Agenda();
            //Não pode haver agendamentos sobrepostos
            DateTime dtConsulta = DateTime.Parse("21/09/2023");
            var hrInicial = DateTime.ParseExact("0800", "HHmm", pt);
            Assert.False(agenda.ConsultaExiste(CPF, dtConsulta, hrInicial));
        }

        [Fact]
        public void AgendamentoErrado()
        {
            var p1 = new Paciente(
                11449750001, "Pedro", DateTime.Parse("01/04/1980"));

            var p = new PacienteController();
            p.Pacientes.Add(p1);

            //Paciente deve estar na lista de cadastro
            var CPF = 29924840089;
            Assert.False(p.PacienteExiste(CPF));

            //Data deve estar no padrão DD/MM/AAAA
            Assert.False(Valida.ValidaDataFormato("21092023"));

            //todas as datas de agendamento
            var datas = new Agenda().Agendamentos;
            //Data deve ser de um periodo futuro            
            Assert.False(Valida.ValidaDataConsulta(datas, "21/09/2020"));

            CultureInfo pt = new("pt-BR");

            //HrInicial deve estar no padrão HHmm
            Assert.False(Valida.ValidaHoraFormato("08:00"));

            //HrInicial deve estar em um período futuro e definida de 15 em 15 minuto
            //ex. 0800, 0815 ou 1730
            Assert.False(Valida.ValidaHrInicial(datas, "0801"));

            //HrFinal deve estar no padrão HHmm
            Assert.False(Valida.ValidaHoraFormato("017"));

            //HrInicial deve estar em um período futuro e definida de 15 em 15 minuto
            //ex. 0800, 0815 ou 1730
            Assert.False(Valida.ValidaHrFinal(datas, "0800", "0815"));

            var agenda = new Agenda();
            //Não pode haver agendamentos sobrepostos
            //Agendamento válido
            DateTime dtConsulta = DateTime.Parse("21/09/2023");
            var hrInicial = DateTime.ParseExact("0800", "HHmm", pt);
            var hrFinal = DateTime.ParseExact("0830", "HHmm", pt);
            agenda.Consultas.Add(new Consulta(11449750001, dtConsulta, hrInicial, hrFinal));

            Assert.False(agenda.ConsultaExiste(29924840089, dtConsulta, hrInicial));
        }

        [Fact]
        public void CancelaConsultaCerto()
        {
            var p1 = new Paciente(
                11449750001, "Pedro", DateTime.Parse("01/04/1980"));

            var p2 = new Paciente(
                29924840089, "Larissa", DateTime.Parse("21/09/2001"));

            var p = new PacienteController();
            p.Pacientes.Add(p1);
            p.Pacientes.Add(p2);

            var agenda = new Agenda();
            CultureInfo pt = new("pt-BR");

            agenda.Consultas.Add(new Consulta(
                    11449750001, DateTime.Parse("21/09/2023"),
                    DateTime.ParseExact("0830", "HHmm", pt),
                    DateTime.ParseExact("0900", "HHmm", pt)));

            agenda.Consultas.Add(new Consulta(
                    29924840089, DateTime.Parse("20/05/2023"),
                    DateTime.ParseExact("0830", "HHmm", pt),
                    DateTime.ParseExact("0900", "HHmm", pt)));

            var CPF = 11449750001;
            Assert.True(p.PacienteExiste(CPF));

            var dtConsulta = DateTime.Parse("21/09/2023");
            var hrInicial = DateTime.ParseExact("0830", "HHmm", pt);
            
            Assert.True(agenda.ConsultaExiste(CPF, dtConsulta, hrInicial));

            var consulta = agenda.PesquisaConsulta(CPF, dtConsulta, hrInicial);

            bool cancelamentoValido = consulta.DtConsulta > DateTime.Now ||
                     consulta.DtConsulta.Equals(DateTime.Now) && 
                     consulta.HrInicial.TimeOfDay > DateTime.Now.TimeOfDay;
            Assert.True(cancelamentoValido);
        }

        [Fact]
        public void CancelaConsultaErrado()
        {
            var p1 = new Paciente(
                11449750001, "Pedro", DateTime.Parse("01/04/1980"));

            var p2 = new Paciente(
                29924840089, "Larissa", DateTime.Parse("21/09/2001"));

            var p = new PacienteController();
            p.Pacientes.Add(p1);
            p.Pacientes.Add(p2);

            var agenda = new Agenda();
            CultureInfo pt = new("pt-BR");

            agenda.Consultas.Add(new Consulta(
                    11449750001, DateTime.Parse("21/09/2023"),
                    DateTime.ParseExact("0830", "HHmm", pt),
                    DateTime.ParseExact("0900", "HHmm", pt)));

            agenda.Consultas.Add(new Consulta(
                    29924840089, DateTime.Parse("03/01/2023"),
                    DateTime.ParseExact("0830", "HHmm", pt),
                    DateTime.ParseExact("0900", "HHmm", pt)));
            
            Assert.False(p.PacienteExiste(64937233025));
         
            Assert.False(Valida.ValidaDataFormato("21/092023"));

            var datas = new Agenda().Agendamentos;
            Assert.False(datas.Exists(dt => dt.Equals(DateTime.Now.AddDays(5))));
            
            Assert.False(Valida.ValidaHoraFormato("08"));
            Assert.False(Valida.ValidaHrInicial(datas,"0801"));

            var CPF = 29924840089;
            var dtConsulta = DateTime.Parse("20/05/2022");
            var hrInicial = DateTime.ParseExact("0830", "HHmm", pt);
            Assert.False(agenda.ConsultaExiste(CPF, DateTime.Now, hrInicial));

            var consulta = agenda.PesquisaConsulta(CPF, DateTime.Parse("03/01/2023"),
                hrInicial);

            bool cancelamentoValido = consulta.DtConsulta > DateTime.Now ||
                     consulta.DtConsulta.Equals(DateTime.Now) &&
                     consulta.HrInicial.TimeOfDay > DateTime.Now.TimeOfDay;
            Assert.False(cancelamentoValido);
        }
    }
}
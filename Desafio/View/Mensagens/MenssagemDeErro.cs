namespace Desafio.View.Mensagens
{
    public class MenssagemDeErro
    {
        public static string OpcaoInvalida { get => "\nErro: opção inválida!\n"; }
        //CPF
        public static string CpfInvalido { get => "\nErro: CPF inválido!\n"; }
        public static string CpfExistente { get => "\nErro: CPF já cadastrado!\n"; }
        public static string CpfInexistente { get => "\nErro: CPF nao cadastrado!\n"; }
        //Nome
        public static string NomeInvalido { get => "\nErro: nome deve ter pelo menos 5 caracteres!\n"; }
        //Data
        public static string DtInvalida { get => "\nErro: data inválida!\n"; }
        public static string DtInvalidaFormato { get => "\nErro: data deve ser fornecida no formato DD/MM/AAAA!\n"; }
        public static string DtConsultaInvalida { get => "\nErro: agendamento deve ser para um período futuro!\n"; }
        public static string DtInvalidaInicial { get => "\nErro: data inicial deve ser maior que a data atual!\n"; }
        public static string DtInvalidaFinal { get => "\nErro: data final deve ser maior que a data inicial!\n"; }
        //Hora
        public static string HrInvalidaFormato { get => "\nErro: hora deve ser fornecida no formato HHMM!\n"; }
        public static string HrInvalidaFuncionamento { get => "\nErro: horário de atendimento é das 8:00h às 19:00h!\n"; }
        public static string HrInvalidaFinal { get => "\nErro: hora final deve ser maior que a hora inicial!\n"; }
        public static string HrInvalidaMultiplos { get => "\nErro: os minutos devem ser multiplos de 15!\n"; }
        public static string HrInvalidaConflito { get => "\nErro: Horario ocupado!\n"; }
        //Consulta
        public static string ConsultaExistente { get => "\nErro: já existe uma consulta agendada nesse horário!\n"; }
        //Agendamento
        public static string AgendamentoInexistente { get => "\nErro: agendamento não encontrado!\n"; }
        //Paciente
        public static string IdadeInvalida { get => "\nErro: paciente deve ter pelo menos 13 anos!\n"; }
        public static string PacienteInexistente { get => "\nErro: paciente não cadastrado!\n"; }
        public static string PacienteAgendado { get => "\nErro: paciente está agendado!\n"; }

    }
}

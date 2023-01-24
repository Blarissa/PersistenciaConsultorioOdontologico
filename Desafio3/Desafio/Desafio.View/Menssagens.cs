namespace Desafio.Desafio.View
{
    public class Menssagens
    {
        //Mensagens de erro
        //opção
        public static string OpcaoInvalida { get => "\nErro: opção inválida!\n"; }
        //CPF
        public static string CpfIvalido { get => "\nErro: CPF inválido!\n"; }
        public static string CpfExistente { get => "\nErro: CPF já cadastrado!\n"; }
        //Nome
        public static string NomeIvalido { get => "\nErro: nome deve ter pelo menos 5 caracteres!\n"; }
        //Data
        public static string DtInvalida { get => "\nErro: data inválida!\n"; }
        public static string DtInvalidaFormato { get => "\nErro: data deve ser fornecida no formato DD/MM/AAAA!\n"; }
        public static string DtConsultaInvalida { get => "\nErro: agendamento deve ser para um período futuro!\n"; }
        public static string DtInicialInvalida { get => "\nErro: data inicial deve ser maior que a data atual!\n"; }
        public static string DtFinalInvalida { get => "\nErro: data final deve ser maior que a data inicial!\n"; }
        //Hora
        public static string HrInvalidaFormato { get => "\nErro: hora deve ser fornecida no formato HHMM!\n"; }
        public static string HrInvalidaFuncionamento { get => "\nErro: horário de atendimento é das 8:00h às 19:00h!\n"; }
        public static string HrFinalInvalida { get => "\nErro: hora final deve ser maior que a hora inicial!\n"; }
        //Consulta
        public static string ConsultExistente { get => "\nErro: já existe uma consulta agendada nesse horário!\n"; }
        //Agendamento
        public static string AgendInexistente { get => "\nErro: agendamento não encontrado!\n"; }
        //Paciente
        public static string IdadeInvalida { get => "\nErro: paciente deve ter pelo menos 13 anos!\n"; }
        public static string PacienteInixistente { get => "\nErro: paciente não cadastrado!\n"; }
        public static string PacienteAgendado { get => "\nErro: paciente está agendado!\n"; }

        //Mensagens de sucesso
        public static string PacienteCadastrado { get => "\nPaciente cadastrado com sucesso!\n"; }
        public static string PacienteExcluido { get => "\nPaciente excluído com sucesso!\n"; }
        public static string AgendamentoRealizado { get => "\nAgendamento realizado com sucesso!\n"; }
        public static string AgendamentoCancelado { get => "\nAgendamento cancelado com sucesso!\n"; }

    }
}

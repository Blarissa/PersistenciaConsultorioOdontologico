using System;

namespace Desafio1
{
    internal class Menssagens
    { 
        //Mensagens de erro
        //CPF
        public static string CpfIvalido { get => "Erro: CPF inválido!"; }
        public static string CpfExistente { get => "Erro: CPF já cadastrado!"; }
        //Nome
        public static string NomeIvalido { get => "Erro: nome deve ter pelo menos 5 caracteres!"; }
        //Data
        public static string DtInvalida { get => "Erro: data inválida!"; }
        public static string DtInvalidaFormato { get => "Erro: data deve ser fornecida no formato DD/MM/AAAA!"; }
        public static string DtConsultaInvalida { get => "Erro: agendamento deve ser para um período futuro!"; }
        //Hora
        public static string HrInvalida { get => "Erro: hora deve ser fornecida no formato HHMM!"; }
        public static string HrInvalidaFuncionamento { get => "Erro: horário de atendimento é das 8:00h às 19:00h!"; }
        public static string HrFinalInvalida { get => "Erro: hora final deve ser maior que a hora inicial!"; }
        //Consulta
        public static string ConsultExistente { get => "Erro: já existe uma consulta agendada nesse horário!"; }
        //Agendamento
        public static string AgendInexistente { get => "Erro: agendamento não encontrado!"; }
        //Paciente
        public static string IdadeInvalida { get => "Erro: paciente deve ter pelo menos 13 anos!"; }
        public static string PacienteInixistente { get => "Erro: paciente não cadastrado!"; }
        public static string PacienteAgendado { get => "Erro: paciente está agendado!"; }

        //Mensagens de sucesso
        public static string PacienteCadastrado { get => "Paciente cadastrado com sucesso!"; }
        public static string PacienteExcluido { get => "Paciente excluído com sucesso!"; }
        public static string AgendamentoRealizado { get => "Agendamento realizado com sucesso!"; }
        public static string AgendamentoCancelado { get => "Agendamento cancelado com sucesso!"; }

    }
}

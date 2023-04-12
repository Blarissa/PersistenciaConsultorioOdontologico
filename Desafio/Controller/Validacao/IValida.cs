using Desafio.Model;

namespace Desafio.Controller.Validacao
{
    public interface IValida
    {
        bool CPF (string CPF);
        bool Nome(string nome);
        bool Data(ETipoDeDataHora tipo, string data);
        bool Data(ETipoDeDataHora tipo, DateTime dataInicio, string dataFim);
        bool DataHora(ETipoDeDataHora tipo, string dataHora);
        bool DataHora(ETipoDeDataHora tipo, DateTime dataHoraInicio, string dataHoraFim);
        bool OpcaoDeListagem(string opcao);
    }
}

using Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data
{
    /// <summary>
    /// Essa interface contém as definições de métodos necessárias para obtenção de dados necessários para operação do sistema
    /// </summary>
    public interface IRecebimentoDeDados
    {   
        /// <summary>
        /// Lê o CPF a partir da entrada de dados 
        /// que implementa IRecebimentoDeDados
        /// </summary>
        public string LerCpf();

        /// <summary>
        /// Lê o Nome a partir da entrada de dados que 
        /// implementa IRecebimentoDeDados
        /// </summary>
        public string LerNome();

        /// <summary>
        /// Lê uma Data a partir da entrada de dados que
        /// implementa IRecebimentoDeDados
        /// </summary>
        /// <param name="tipo">Variável para diferenciação da leitura para datas de natureza diferente</param>
        public string LerData(TipoDeData tipo);

        /// <summary>
        /// Lê a opção de listagem preferida da agenda
        /// a partir da entrada de dados que implementa
        /// IRecebimentoDeDados
        /// </summary>
        public string LerOpcaoDeListagemDaAgenda();

        /// <summary>
        /// Lê a hora a partir da entrada de dados que implementa IRecebimentoDeDados
        /// </summary>
        /// <param name="tipo">Variável para diferenciação da leitura para horários de natureza diferente</param>
        public string LerHora(TipoDeHora tipo);
    }
}

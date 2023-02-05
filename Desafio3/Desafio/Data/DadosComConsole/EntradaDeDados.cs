using Desafio.Model;

namespace Desafio.Data.DadosComConsole
{
    public class EntradaDeDados
    {
        #region Documentation
        /// <summary>   Realiza a leitura do <see cref="Paciente.CPF"/> via console. </summary>
        ///
        /// <returns>
        ///     <list type="bullet">
        ///       <item>
        ///       Se o valor for diferente de <see langword= "null"/>, retorna uma <see cref="string"/>
        ///       com valor do <see langword= "CPF"/>.
        ///       </item>
        ///       <item>Caso contrário, retorna uma <see cref="string"/> <see langword= "null"/>.</item>
        ///     </list>
        /// </returns>
        #endregion

        public static string? LerCPF()
        {
            Console.WriteLine("CPF:");
            return Console.ReadLine();
        }

        #region Documentation
        /// <summary>   Realiza a leitura do <see cref="Paciente.Nome"/> via console. </summary>
        ///
        /// <returns>
        ///     <list type="bullet">
        ///       <item>
        ///       Se o valor for diferente de <see langword= "null"/>, retorna uma <see cref="string"/>
        ///       com valor do <see langword= "nome"/>.
        ///       </item>
        ///       <item>Caso contrário, retorna uma <see cref="string"/> <see langword= "null"/>.</item>
        ///     </list>
        /// </returns>
        #endregion

        public static string? LerNome()
        {
            Console.WriteLine("Nome:");           
            return Console.ReadLine();
        }

        #region Documentation
        /// <summary>   Realiza a leitura da <see langword="data ou hora"/> via console. </summary>
        ///
        /// <param name="tipo">
        ///     <see cref="int"/> referente ao <see cref="TipoDataHora"/> que vai ser lido.
        /// </param>
        ///
        /// <returns>
        ///     <list type="bullet">
        ///       <item>
        ///       Se o valor for diferente de <see langword= "null"/>, retorna uma <see cref="string"/>
        ///       com valor da <see langword= "data ou hora"/>.
        ///       </item>
        ///       <item>Caso contrário, retorna uma <see cref="string"/> <see langword= "null"/>.</item>
        ///     </list>
        /// </returns>
        #endregion

        public static string? LerDataHora(int tipo)
        {
            Console.WriteLine(CabecalhoDataHora(tipo));
            return Console.ReadLine();
        }

        #region Documentation
        /// <summary>
        ///     Realiza a leitura da <see langword="opção de listagem da agenda"/> via console.
        /// </summary>        
        ///
        /// <returns>
        ///     <list type="bullet">
        ///       <item>
        ///       Se o valor for diferente de <see langword= "null"/>, retorna uma <see cref="string"/>
        ///       com valor da <see langword= "opção de listagem da agenda"/>.
        ///       </item>
        ///       <item>Caso contrário, retorna uma <see cref="string"/> <see langword= "null"/>.</item>
        ///     </list>
        /// </returns>
        #endregion

        public static string? LerOpcaoListagemDaAgenda()
        {
            Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
            return Console.ReadLine().ToUpper();
        }

        #region Documentation
        /// <summary>
        ///     Devolde o cabeçalho de <see cref="LerDataHora(int)"/> de acordo com o <see cref="TipoDataHora"/>.            
        /// </summary>
        ///
        /// <param name="tipo">
        ///     <see cref="int"/> referente ao <see cref="TipoDataHora"/> que vai ser lido.
        /// </param>
        ///
        /// <returns>   Uma <see cref="string"/> com o cabeçalho da data ou hora. </returns>
        #endregion

        private static string CabecalhoDataHora(int tipo)
        {
            string str = "";

            switch (tipo)
            {
                case 0:
                    str = "Data de nascimento: ";
                    break;

                case 1:
                    str = "Data da consulta: ";
                    break;

                case 2:
                    str = "Data inicial: ";
                    break;

                case 3L:
                    str = "Data final: ";
                    break;

                case 4:
                    str = "Hora inicial: ";
                    break;

                case 5:
                    str = "Hora final: ";
                    break;
            }
            return str;
        }
 
    }
}

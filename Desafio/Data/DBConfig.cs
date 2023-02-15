namespace Desafio.Data
{
    #region Documentation
    /// <summary>   Configurações do banco de dados <see langword="ConsultorioDB"/>. </summary>
    #endregion

    internal class DBConfig
    {
        public string Host { get =>"localhost"; }
        public string User { get =>"postgres"; }
        public string Database { get => "ConsultorioDB"; }
        public string Senha { get => "mypass"; }     
    }
}
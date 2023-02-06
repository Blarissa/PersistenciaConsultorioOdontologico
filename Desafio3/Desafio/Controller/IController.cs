namespace Desafio.Controller
{
    #region Documentation
    /// <summary>   Define uma interface para os controladores. </summary>
    #endregion

    public interface IController
    {
        void Adiciona();
        void Remove();
        void ListarPorChave();
    }
}
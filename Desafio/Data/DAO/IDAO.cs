namespace Desafio.Data.DAO
{
    public interface IDAO<T>
    {
        void Adicionar(T tipo);
        void Remover(T tipo);
        IList<T> ListaTodos();
    }
}

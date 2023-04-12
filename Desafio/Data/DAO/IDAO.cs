using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DAO
{
    public interface IDAO<T>
    {
        void Adicionar(T tipo);
        void Remover(T tipo);
        IList<T> ListaTodos();
    }
}

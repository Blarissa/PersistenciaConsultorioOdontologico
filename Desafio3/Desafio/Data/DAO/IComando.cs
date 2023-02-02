using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DAO
{
    internal interface IComando<T>
    {
        void Adicionar(T obj);
        void Remover(T obj);
        IEnumerable<T> ListarTodos();
    }
}

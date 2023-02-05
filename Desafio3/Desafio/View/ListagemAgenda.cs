using Desafio.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.View
{
    internal class ListagemAgenda : IListagem
    {
        ConsultaDAO dao;

        public void ListarPorChave(int id)
        {
            var lista = dao.ListaPorId(id);
        }

        public void ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

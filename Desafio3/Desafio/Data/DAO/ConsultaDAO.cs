using Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DAO
{
    internal class ConsultaDAO : IComando<Consulta>
    {
        public void Adicionar(Consulta tipo)
        {
            throw new NotImplementedException();
        }

        public IList<Consulta> ListaTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Consulta tipo)
        {
            throw new NotImplementedException();
        }

        internal IList<Consulta> ListaPorCPF(long CPF)
        {
            throw new NotImplementedException();
        }

        internal Consulta ListaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

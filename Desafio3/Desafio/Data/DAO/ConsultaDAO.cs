using Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DAO
{
    public class ConsultaDAO : IComando<Consulta>
    {
        ConsultorioContexto contexto;

        #region Documentation
        /// <summary>   Inicializa uma instância da classe <see cref="ConsultaDAO" />. </summary>
        ///
        /// <param name="contexto"> Referente a um objeto do <see cref="ConsultorioContexto" />. </param>
        #endregion

        public ConsultaDAO(ConsultorioContexto contexto)
        {
            this.contexto = contexto;
        }

        public void Adicionar(Consulta tipo)
        {
            contexto.Consultas.Add(tipo);
            contexto.SaveChanges();
        }

        public IList<Consulta> ListaTodos()
        {
            List<Consulta> resposta = contexto.Consultas.ToList();

            foreach(Consulta c in resposta) {
                c.Paciente = contexto.Pacientes.Find(c.CPFPaciente);
            }

            return resposta;
        }

        public void Remover(Consulta tipo)
        {
            contexto.Consultas.Remove(tipo);
            contexto.SaveChanges();
        }

        internal IList<Consulta> ListaPorCPF(long CPF)
        {
            return contexto.Consultas.Where(cnslt => cnslt.CPFPaciente.Equals(CPF)).ToList();
        }

        internal Consulta ListaPorId(int id)
        {
            return contexto.Consultas.Find(id);
        }
    }
}

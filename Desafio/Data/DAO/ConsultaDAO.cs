using Desafio.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data.DAO
{
    public class ConsultaDAO : IDAO<Consulta>
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

        public void Adicionar(Consulta consulta)
        {
            contexto.Consultas.Add(consulta);
            contexto.SaveChanges();
        }

        public Consulta? ListaPorId(int id)
        {
            return contexto.Consultas
                .Include(c => c.Paciente)
                .FirstOrDefault(c => c.Id == id);
        }

        public IList<Consulta> ListaTodos()
        {           
            return contexto.Consultas
                .Include(c => c.Paciente)
                .ToList();
        }

        public void Remover(Consulta consulta)
        {
            contexto.Consultas.Remove(consulta);
            contexto.SaveChanges();
        }

        public IList<Consulta> ListaPorCPF(long CPF)
        {
            return contexto.Consultas
                .Include(c => c.Paciente)
                .Where(c => c.CPFPaciente.Equals(CPF))
                .ToList();
        }
        
    }
}

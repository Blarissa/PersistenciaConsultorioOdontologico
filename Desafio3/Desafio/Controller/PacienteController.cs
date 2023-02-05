using Desafio.Data.DAO;
using Desafio.Model;

namespace Desafio.Controller
{
    public class PacienteController
    {

        PacienteDAO dao;

        public void Adiciona()
        {
            long CPF = EntradaDeDados.RetornaCPF();   
            string nome = EntradaDeDados.RetornaNome();
            DateTime data = EntradaDeDados.RetornaData(0);

            dao.Adicionar(
                new Paciente() { 
                    CPF = CPF, 
                    Nome = nome, 
                    DtNascimento = data
                });
        }

        //Removendo paciente
        public void Remove()
        {
            long CPF = EntradaDeDados.RetornaCPF();
            var paciente = dao.ListaPorCPF(CPF);

            dao.Remover(paciente);
        }

        //terminar
        //public string? ListarTodosPacientes()
        //{
        //    return dao.ListaTodos();
        //}
        
    }
}

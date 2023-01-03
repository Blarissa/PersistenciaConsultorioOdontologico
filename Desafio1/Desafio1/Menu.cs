using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class Menu
    {
        PacienteController pacienteController = new();
        Agenda agenda = new ();

        //Chama menu principal
        public static void Principal()
        {
            Console.WriteLine("Menu Principal" +
                   "\n1-Cadastro de pacientes" +
                   "\n2-Agenda" +
                   "\n3-Fim");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                //Chama menu de pacientes
                case 1:
                    return new Menu().Pacientes();
                    
                //Chama menu da agenda
                case 2:
                    return new Menu().Agenda();                    

                //Finaliza programa
                case 3:
                    break;

                //Ler opção novamente
                default:
                    Console.WriteLine(Menssagens.opcaoInvalida);
                    return Principal();                    
            }
        }
        
        //Chama menu de pacientes
        public int Pacientes()
        {
            Console.WriteLine("Menu do Cadastro de Pacientes" +
                   "\n1-Cadastrar novo paciente" +
                   "\n2-Excluir paciente" +
                   "\n3-Listar pacientes (ordenado por CPF)" +
                   "\n4-Listar pacientes (ordenado por nome)" +
                   "\n5-Voltar p/ menu principal");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                //Cadastrar novo paciente
                case 1:
                    pacienteController.Adiciona();
                    break;

                //Excluir paciente
                case 2:
                    pacienteController.Remove();
                    break;

                //Listar pacientes (ordenado por CPF)
                case 3:
                    Console.WriteLine(pacienteController.PacientesOrdemCPF());
                    break;

                //Listar pacientes (ordenado por nome)
                case 4: Console.WriteLine(pacienteController.PacientesOrdemNome());
                    break;

                //Voltar para o menu principal
                case 5:
                    break;

                //Ler opção novamente
                default:
                    Console.WriteLine(Menssagens.opcaoInvalida);
                    return Pacientes();                    
            }
        }

        //Chama menu da agenda
        public int Agenda()
        {
            Console.WriteLine("Agenda" +
                   "\n1-Agendar consulta" +
                   "\n2-Cancelar agendamento" +
                   "\n3-Listar agenda" +
                   "\n4-Voltar p/ menu principal");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                //Agendar consulta
                case 1: agenda.Agendar();
                    break;

                //Cancelar agendamento
                case 2: agenda.Cancelar();
                    break;

                //Listar agenda
                case 3: 
                    break;

                //Voltar para o menu principal
                case 4:
                    break;

                //Ler opção novamente
                default:
                    Console.WriteLine(Menssagens.opcaoInvalida);
                    return Agenda();
            }
        }
    }
}

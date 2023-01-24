using Desafio.Desafio.Controllers;

namespace Desafio.Desafio.View
{
    internal class Menu
    {
        readonly PacienteController pacienteController = new();
        readonly Agenda agenda = new ();

        //Chama menu principal
        public static int Principal()
        {
            Console.WriteLine("Menu Principal" +
                   "\n1-Cadastro de pacientes" +
                   "\n2-Agenda" +
                   "\n3-Fim\n");

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
                case 3: return -1;

                //Ler opção novamente
                default:
                    Console.WriteLine(Menssagens.OpcaoInvalida);
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
                   "\n5-Voltar p/ menu principal\n");

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
                case 3: Console.WriteLine(pacienteController.PacientesOrdemCPF());
                    break;

                //Listar pacientes (ordenado por nome)
                case 4: Console.WriteLine(pacienteController.PacientesOrdemNome());
                    break;

                //Voltar para o menu principal
                case 5: return Menu.Principal();

                //Ler opção novamente
                default:
                    Console.WriteLine(Menssagens.OpcaoInvalida);
                    return Pacientes();                    
            }
            return Pacientes();
        }

        //Chama menu da agenda
        public int Agenda()
        {
            Console.WriteLine("Agenda" +
                   "\n1-Agendar consulta" +
                   "\n2-Cancelar agendamento" +
                   "\n3-Listar agenda" +
                   "\n4-Voltar p/ menu principal\n");

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
                case 3: agenda.Listagem();
                    break;

                //Voltar para o menu principal
                case 4: return Menu.Principal();

                //Ler opção novamente
                default:
                Console.WriteLine(Menssagens.OpcaoInvalida);
                return Agenda();
            }
            return Agenda();
        }
    }
}

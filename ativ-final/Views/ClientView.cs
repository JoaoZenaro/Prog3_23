using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Models;
using ativ_final.Data;
using ativ_final.Controllers;

namespace ativ_final.Views
{
    public class ClientView
    {
        private ClientController clientController;

        public ClientView()
        {
            clientController = new ClientController();
            this.Init();
        }

        public void Init()
        {
            int option;

            do
            {
                Utils.BoxPrint("Clientes");

                var menu = new Menu(new string[] {"1 - Inserir", "2 - Listar", "3 - Exprtar", "4 - Importar", "5 - Pesquisar", "6 - Voltar"});
                menu.Draw();

                Console.Write("\nOpção: ");
                Int32.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1: Insert(); break;
                    case 2: List(); break;
                    case 3: Export(); break;
                    case 4: Import(); break;
                    case 5: SearchByName(); break; 
                    case 6: break;
                    default:
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.WriteLine("Opção inválida.");
                        Utils.Pause();
                        break;
                }
            } while (option != 6);            
        }

        private void List()
        {
            List<Client> listagem = clientController.List();

            for (int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }

            Utils.Pause();
        }

        private string Print(Client client)
        {
            string retorno = "";
            retorno += $"Id: {client.Id} \n";
            retorno += $"Nome: {client.FirstName} {client.LastName} \n";
            retorno += "-------------------------------------------";

            return retorno;
        }

        private void Insert()
        {
            Client client = new Client();
            client.Id = clientController.GetNextId();

            Console.Write("Informe o primeiro nome: ");
            client.FirstName = Console.ReadLine();

            Console.Write("Informe o segundo nome: ");
            client.LastName = Console.ReadLine();

            Console.Write("Informe o CPF: ");
            client.CPF = Console.ReadLine();

            Console.Write("Informe o email: ");
            client.Email = Console.ReadLine();

            bool retorno = clientController.Insert(client);

            if (retorno)
                Console.WriteLine("Cliente Inserido com sucesso!");

            Utils.Pause();
        }

        private void Export()
        {
            if (clientController.ExportToTextFile())
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Ooooopss!");

            Utils.Pause();
        }

        private void Import()
        {
            if (clientController.ImportFromTxtFile())
                Console.WriteLine("Arquivo importado com sucesso!");
            else
                Console.WriteLine("Ooooopss!");

            Utils.Pause();
        }

        private void SearchByName()
        {
            Console.Write("Digite o nome para pesquisar: ");
            string? input = Console.ReadLine();
            
            List<Client>? clients = new List<Client>(); 
            clients = clientController.SearchByName(input);

            if (clients?.Count > 0)
            {
                foreach (Client client in clients)
                {
                    Console.WriteLine(client.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nenhum registro encontrado.");
            }

            Utils.Pause();
        }
    }
}
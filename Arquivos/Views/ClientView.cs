using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Models;
using Arquivos.Data;
using Arquivos.Controllers;

namespace Arquivos.Views
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
            var menu = new Menu(new string[] {"1 - Inserir Cliente", "2 - Listar Clientes", "3 - Exprtar Clientes", "4 - Importar Clientes"});
            menu.Draw();
            
            int option = 0;
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1: Insert(); break;
                case 2: List(); break;
                case 3: Export(); break;
                case 4: Import(); break;
                default:
                    break;
            }
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
            retorno += $"Nome: {client.FirstName} {client.LastName}";
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
        }

        private void Export()
        {
            if (clientController.ExportToTextFile())
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Ooooopss!");
        }

        private void Import()
        {
            if (clientController.ImportFromTxtFile())
                Console.WriteLine("Arquivo importado com sucesso!");
            else
                Console.WriteLine("Ooooopss!");
        }
    }
}
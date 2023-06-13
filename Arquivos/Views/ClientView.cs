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
            Console.WriteLine("1 - Inserir Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Exprtar Clientes");
            Console.WriteLine("4 - Importar Clientes\n");
            int option = 0;
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Insert();
                    break;
                default:
                    break;

                case 2:
                    List();
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
    }
}
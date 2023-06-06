using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arquivos.Data;
using arquivos.Models;

namespace arquivos.Views
{
    public class ClientView
    {
        public ClientView()
        {
            this.Init();
        }

        public void Init()
        {
            Console.WriteLine(new String('*', 30));
            Console.WriteLine("Você está em clientes");
            Console.WriteLine(new String('*', 30));
            Console.WriteLine("");

            Console.WriteLine("1 - Inserir Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Exportar Clientes");
            Console.WriteLine("4 - Importar Clientes");
            Console.WriteLine("");

            int option = 0;
            switch (option)
            {
                case 1:
                    this.Insert();
                    break;
                case 2:
                    this.List();
                    break;
                case 3:
                    this.Export();
                    break;
                case 4:
                    this.Import();
                    break;
                default:
                    break;
            }
        }

        private void Insert()
        {
            Client client = new Client();
            client.Id = DataSet.clients.Count + 1;

            Console.Write("Nome do cliente: ");
            client.FirstName = Console.ReadLine();

            Console.Write("Sobrenome do cliente: ");
            client.LastName = Console.ReadLine();

            Console.Write("CPF do cliente: ");
            client.CPF = Console.ReadLine();

            Console.Write("Email do cliente: ");
            client.Email = Console.ReadLine();

            DataSet.clients.Add(client);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Controllers;
using ativ_final.Models;

namespace ativ_final.Views
{
    public class ClinicView
    {
        private ClinicController clinicController;

        public ClinicView()
        {
            clinicController = new ClinicController();
            this.Init();
        }

        public void Init()
        {

            int option;

            do
            {
                Utils.BoxPrint("Clínicas");

                var menu = new Menu(new string[] { "1 - Inserir", "2 - Listar", "3 - Exportar", "4 - Importar", "5 - Pesquisar (nome)", "6 - Voltar" });
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
            List<Clinic> listagem = clinicController.List();

            for (int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }

            Utils.Pause();
        }

        private string Print(Clinic clinic)
        {
            string retorno = "";
            retorno += $"Id: {clinic.Id} \n";
            retorno += $"Nome: {clinic.Name} \n";
            retorno += $"Telefone: {clinic.PhoneNumber} \n";
            retorno += $"Endereço: {clinic.Address} \n";
            retorno += "-------------------------------------------";

            return retorno;
        }

        private void Insert()
        {
            Clinic clinic = new()
            {
                Id = clinicController.GetNextId()
            };

            Console.Write("Informe o nome: ");
            clinic.Name = Console.ReadLine();

            Console.Write("Informe o telefone: ");
            clinic.PhoneNumber = Console.ReadLine();

            Console.Write("Informe o endereço: ");
            clinic.Address = Console.ReadLine();

            if (clinicController.Insert(clinic))
                Console.WriteLine("Animal Inserido com sucesso!");

            Utils.Pause();
        }

        private void Export()
        {
            if (clinicController.ExportToTextFile())
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Erro!");

            Utils.Pause();
        }

        private void Import()
        {
            if (clinicController.ImportFromTxtFile())
                Console.WriteLine("Arquivo importado com sucesso!");
            else
                Console.WriteLine("Erro!");

            Utils.Pause();
        }

        private void SearchByName()
        {
            Console.Write("Digite o nome para pesquisar: ");
            string? input = Console.ReadLine();

            List<Clinic>? clinics = new List<Clinic>();
            clinics = clinicController.SearchByName(input);

            if (clinics?.Count > 0)
            {
                foreach (Clinic clinic in clinics)
                {
                    Console.WriteLine(clinic.ToString());
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Controllers;
using ativ_final.Models;

namespace ativ_final.Views
{
    public class AnimalView
    {
        private AnimalController animalController;

        public AnimalView()
        {
            animalController = new AnimalController();
            this.Init();
        }

        public void Init()
        {

            int option;

            do
            {
                Utils.BoxPrint("Animais");

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
            List<Animal> listagem = animalController.List();

            for (int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }

            Utils.Pause();
        }

        private string Print(Animal animal)
        {
            string retorno = "";
            retorno += $"Id: {animal.Id} \n";
            retorno += $"Nome: {animal.Name} \n";
            retorno += $"Espécie: {animal.Species} \n";
            retorno += $"Raça: {animal.Breed} \n";
            retorno += $"Dono: {animal.Owner} \n";
            retorno += "-------------------------------------------";

            return retorno;
        }

        private void Insert()
        {
            Animal animal = new()
            {
                Id = animalController.GetNextId()
            };

            Console.Write("Informe o nome: ");
            animal.Name = Console.ReadLine();

            Console.Write("Informe a espécie: ");
            animal.Species = Console.ReadLine();

            Console.Write("Informe a raça: ");
            animal.Breed = Console.ReadLine();

            Console.Write("Informe o nome do dono: ");
            animal.Owner = Console.ReadLine();

            if (animalController.Insert(animal))
                Console.WriteLine("Animal Inserido com sucesso!");

            Utils.Pause();
        }

        private void Export()
        {
            if (animalController.ExportToTextFile())
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Erro!");

            Utils.Pause();
        }

        private void Import()
        {
            if (animalController.ImportFromTxtFile())
                Console.WriteLine("Arquivo importado com sucesso!");
            else
                Console.WriteLine("Erro!");

            Utils.Pause();
        }
 
        private void SearchByName()
        {
            Console.Write("Digite o nome para pesquisar: ");
            string? input = Console.ReadLine();
            
            List<Animal>? animals = new List<Animal>(); 
            animals = animalController.SearchByName(input);

            if (animals?.Count > 0)
            {
                foreach (Animal animal in animals)
                {
                    Console.WriteLine(animal.ToString());
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
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

                var menu = new Menu(new string[] { "1 - Inserir", "2 - Listar", "3 - Exportar", "4 - Importar", "5 - Pesquisar por id", "6 - Pesquisar por nome", "7 - Voltar" });
                menu.Draw();

                Console.Write("\nOpção: ");
                Int32.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1: Insert(); break;
                    case 2: List(); break;
                    case 3: Export(); break;
                    case 4: Import(); break;
                    // case 5: SearchById(); break;
                    // case 6: SearchByName(); break;
                    case 7: break;
                    default:
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.WriteLine("Opção inválida.");
                        Utils.Pause();
                        break;
                }
            } while (option != 7);
        }

        private void List()
        {
            List<Animal> listagem = animalController.List();

            for (int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }
        }

        private string Print(Animal animal)
        {
            string retorno = "";
            retorno += $"Id: {animal.Id} \n";
            retorno += $"Nome: {animal.Name}";
            retorno += $"Espécie: {animal.Species}";
            retorno += $"Raça: {animal.Breed}";
            retorno += $"Dono: {animal.Owner}";
            retorno += "-------------------------------------------";

            return retorno;
        }

        private void Insert()
        {
            Animal animal = new Animal();
            animal.Id = animalController.GetNextId();

            Console.Write("Informe o nome: ");
            animal.Name = Console.ReadLine();

            Console.Write("Informe a espécie: ");
            animal.Species = Console.ReadLine();

            Console.Write("Informe a raça: ");
            animal.Breed = Console.ReadLine();

            Console.Write("Informe o nome do dono: ");
            animal.Owner = Console.ReadLine();

            bool retorno = animalController.Insert(animal);

            if (retorno)
                Console.WriteLine("Animal Inserido com sucesso!");
        }

        private void Export()
        {
            if (animalController.ExportToTextFile())
                Console.WriteLine("Arquivo gerado com sucesso!");
            else
                Console.WriteLine("Ooooopss!");

            Utils.Pause();
        }

        private void Import()
        {
            if (animalController.ImportFromTxtFile())
                Console.WriteLine("Arquivo importado com sucesso!");
            else
                Console.WriteLine("Ooooopss!");

            Utils.Pause();
        }
 
    }
}
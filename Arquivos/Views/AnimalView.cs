using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Models;
using Arquivos.Data;
using Arquivos.Controllers;

namespace Arquivos.Views
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

            var menu = new Menu(new string[] {"1 - Inserir Animal", "2 - Listar Animais", "3 - Exprtar Animais", "4 - Importar Animais"});
            menu.Draw();

            int option = 0;
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: Insert(); break;
                case 2: List(); break;
                default:
                    break;
            }
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
    }
}
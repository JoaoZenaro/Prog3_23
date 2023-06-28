using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Data;
using ativ_final.Models;

namespace ativ_final.Controllers
{
    public class AnimalController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Animals.txt";

        public List<Animal> List()
        {
            return DataSet.Animals;
        }

        public bool Insert(Animal animal)
        {
            if (animal == null)
                return false;

            if (animal.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(animal.Name) ||
                string.IsNullOrWhiteSpace(animal.Species) || 
                string.IsNullOrWhiteSpace(animal.Breed) || 
                string.IsNullOrWhiteSpace(animal.Owner))
                return false;

            DataSet.Animals.Add(animal);
            return true;
        }

        public int GetNextId()
        {
            int tam = DataSet.Animals.Count;

            if (tam > 0)
                return DataSet.Animals[tam - 1].Id + 1;
            else
                return 1;
        }

         public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;

            foreach (Animal animal in DataSet.Animals)
            {
                fileContent += $"{animal.Id};{animal.Name};{animal.Species};{animal.Breed};{animal.Owner}";
                fileContent += "\n";
            }

            try
            {
                StreamWriter sw = File.CreateText($"{directoryName}/{fileName}");

                sw.Write(fileContent);
                sw.Close();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Erro ao manipular o arquivo.");
                Console.WriteLine(ioEx.Message);
                return false;
            }

            return true;
        }

        public bool ImportFromTxtFile()
        {
            try
            {
                StreamReader sr = new StreamReader($"{directoryName}/{fileName}");

                string? line = string.Empty;

                line = sr.ReadLine();

                while (line != null)
                {
                    Animal animal = new Animal();

                    string[] animalData = line.Split(';');

                    animal.Id = Convert.ToInt32(animalData[0]);
                    animal.Name = animalData[1];
                    animal.Species = animalData[2];
                    animal.Breed = animalData[3];
                    animal.Owner = animalData[4];

                    DataSet.Animals.Add(animal);

                    line = sr.ReadLine();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao importar os dados do arquivo.");
                Console.WriteLine(ex);
                return false;
            }
        }
 
    }
}
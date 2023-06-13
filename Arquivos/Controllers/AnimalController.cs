using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Controllers
{
    public class AnimalController
    {

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
    }
}
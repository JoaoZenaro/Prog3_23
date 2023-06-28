using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Data;
using ativ_final.Models;

namespace ativ_final.Controllers
{
    public class VetController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Veterinarian.txt";

        public List<Veterinarian> List()
        {
            return DataSet.Vets;
        }

        public bool Insert(Veterinarian vet)
        {
            if (vet == null)
                return false;

            if (vet.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(vet.FirstName) ||
                string.IsNullOrWhiteSpace(vet.LastName) ||
                string.IsNullOrWhiteSpace(vet.CPF) ||
                (vet.Clinic == 0))
                return false;

            DataSet.Vets.Add(vet);
            return true;
        }

        public int GetNextId()
        {
            int tam = DataSet.Vets.Count;

            if (tam > 0)
                return DataSet.Vets[tam - 1].Id + 1;
            else
                return 1;
        }

        public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;

            foreach (Veterinarian vet in DataSet.Vets)
            {
                fileContent += $"{vet.Id};{vet.FirstName};{vet.LastName};{vet.CPF};{vet.Clinic}";
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
                    Veterinarian vet = new();

                    string[] vetData = line.Split(';');

                    vet.Id = Convert.ToInt32(vetData[0]);
                    vet.FirstName = vetData[1];
                    vet.LastName = vetData[2];
                    vet.CPF = vetData[3];
                    vet.Clinic = Convert.ToInt32(vetData[4]);

                    DataSet.Vets.Add(vet);

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

        public List<Veterinarian>? SearchByName(string? name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            List<Veterinarian>? vets = new List<Veterinarian>();

            for (int i = 0; i < DataSet.Vets.Count; i++)
            {
                if (DataSet.Vets[i].FullName.ToLower().Contains(name.ToLower()))
                {
                    vets.Add(DataSet.Vets[i]);
                }
            }

            return vets;
        }
    }
}
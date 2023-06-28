using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Data;
using ativ_final.Models;

namespace ativ_final.Controllers
{
    public class ClinicController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Clinics.txt";

        public List<Clinic> List()
        {
            return DataSet.Clinics;
        }

        public bool Insert(Clinic clinic)
        {
            if (clinic == null)
                return false;

            if (clinic.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(clinic.Name) ||
                string.IsNullOrWhiteSpace(clinic.PhoneNumber) || 
                string.IsNullOrWhiteSpace(clinic.Address))
                return false;

            DataSet.Clinics.Add(clinic);
            return true;
        }

        public int GetNextId()
        {
            int tam = DataSet.Clinics.Count;

            if (tam > 0)
                return DataSet.Clinics[tam - 1].Id + 1;
            else
                return 1;
        }

         public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;

            foreach (Clinic clinic in DataSet.Clinics)
            {
                fileContent += $"{clinic.Id};{clinic.Name};{clinic.PhoneNumber};{clinic.Address}";
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
                    Clinic clinic = new();

                    string[] clinicData = line.Split(';');

                    clinic.Id = Convert.ToInt32(clinicData[0]);
                    clinic.Name = clinicData[1];
                    clinic.PhoneNumber = clinicData[2];
                    clinic.Address = clinicData[3];

                    DataSet.Clinics.Add(clinic);

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
 
        public List<Clinic>? SearchByName(string? name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) {
                return null;
            }

            List<Clinic>? clinics = new List<Clinic>();

            for (int i = 0; i < DataSet.Clinics.Count; i++)
            {
                if (DataSet.Clinics[i].Name.ToLower().Contains(name.ToLower())) {
                    clinics.Add(DataSet.Clinics[i]);
                }
            }

            return clinics;
        }
    }
}
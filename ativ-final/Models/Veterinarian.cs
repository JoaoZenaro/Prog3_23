using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ativ_final.Data;

namespace ativ_final.Models
{
    public class Veterinarian
    {
        public Veterinarian()
        {
        }

        public Veterinarian(int id, string? firstName, string? lastName, string? cPF, int clinic)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            Clinic = clinic;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CPF { get; set; }
        public int Clinic { get; set; }

        public string ClinicName()
        {
            Clinic? clinic = DataSet.Clinics.FirstOrDefault(c => c.Id == this.Clinic);

            return string.IsNullOrEmpty(clinic?.Name) ? "Invalido" : clinic.Name;
        }
        public string FullName => $"{this.FirstName} {this.LastName}";

        public override string ToString()
        {
            return $"Id: {this.Id}; Nome: {this.FullName}; CPF: {this.CPF}; Clinica: {this.ClinicName}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ativ_final.Models
{
    public class Clinic
    {
        public Clinic()
        {
        }

        public Clinic(int id, string? name, string? phoneNumber, string? address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}; Nome: {this.Name}; Telefone: {this.PhoneNumber}; Endereço: {this.Address}";
        }
    }
}
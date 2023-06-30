using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ativ_final.Models
{
    public class Client
    {
        public Client()
        {
        }

        public Client(int id, string? firstName, string? lastName, string? cPF, string? email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            Email = email;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public override string ToString()
        {
            return $"Id: {this.Id}; Name: {this.FullName} ";//; LastName: {this.LastName}; CPF: {this.CPF}; Email: {this.Email}
        }
    }
}
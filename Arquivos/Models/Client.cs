using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Models
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
        
        public int Id {get; set;}
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public string? CPF {get; set;}
        public string? Email {get; set;}
    }
}
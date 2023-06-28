using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ativ_final.Models
{
    public class Veterinarian
    {
        public Veterinarian()
        {
        }

        public Veterinarian(int id, string? firstName, string? lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
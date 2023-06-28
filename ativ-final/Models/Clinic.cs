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

        public Clinic(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ativ01.classes
{
    public class Manager : Person
    {
        public DateTime HireDate { get; set; }
        public string? Department { get; set; }
    }
}
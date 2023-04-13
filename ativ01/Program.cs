namespace ativ01.classes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[] {
            new Manager()
            {
                Name = "Pedro Souza",
                DateOfBirth = new DateTime(1978, 5, 23),
                Gender = "Masculino",
                HireDate = new DateTime(2005, 3, 15),
                Department = "Vendas"
            },
            new Supervisor()
            {
                Name = "Ana Santos",
                DateOfBirth = new DateTime(1986, 12, 10),
                Gender = "Feminino",
                Team = "Produção",
                Shift = "Noturno"
            },
            new Worker()
            {
                Name = "João da Silva",
                DateOfBirth = new DateTime(1997, 9, 5),
                Gender = "Masculino",
                JobTitle = "Montador",
                Salary = 35000.00m
            },
            new Manager()
            {
                Name = "Maria Oliveira",
                DateOfBirth = new DateTime(1980, 7, 17),
                Gender = "Feminino",
                HireDate = new DateTime(2010, 6, 1),
                Department = "Marketing"
            },
            new Supervisor()
            {
                Name = "Miguel Pereira",
                DateOfBirth = new DateTime(1992, 3, 21),
                Gender = "Masculino",
                Team = "Transporte",
                Shift = "Diurno"
            }
            };

            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"Pessoa {i + 1}:");
                Console.WriteLine($"Nome: {people[i].Name}");
                Console.WriteLine($"Data de nascimento: {people[i].DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"Gênero: {people[i].Gender}");

                if (people[i] is Manager)
                {
                    Manager manager = (Manager)people[i];
                    Console.WriteLine($"Data de contratação: {manager.HireDate.ToShortDateString()}");
                    Console.WriteLine($"Departamento: {manager.Department}");
                }
                else if (people[i] is Supervisor)
                {
                    Supervisor supervisor = (Supervisor)people[i];
                    Console.WriteLine($"Time: {supervisor.Team}");
                    Console.WriteLine($"Turno: {supervisor.Shift}");
                }
                else if (people[i] is Worker)
                {
                    Worker worker = (Worker)people[i];
                    Console.WriteLine($"Cargo: {worker.JobTitle}");
                    Console.WriteLine($"Salário: {worker.Salary}");
                }

                Console.WriteLine();
            }
        }
    }
}
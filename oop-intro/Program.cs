using oop_intro.classes;

Animal[] animals = new Animal[]
{
    new Cat
    {
        Name = "Cleber",
        BirthDate = new(year: 2022, month: 08, day: 02),
        IsDomestic = true,
        Legs = 4,
    },
    new Spider
    {
        Name = "Venenosa",
        BirthDate = new(year: 2022, month: 03, day: 22),
        Legs = 8,
        IsVenomous = true,
    },
    new Spider
    {
        Name = "Boazinha",
        BirthDate = System.DateTime.Today,
        Legs = 8,
        IsVenomous = false,
    },
    new Spider
    {
        Name = "Eddie Brock",
        BirthDate = System.DateTime.Today,
        Legs = 8,
        IsVenomous = false,
    },
    new Animal
    {
        Name = "Elton John",
        BirthDate = new(year: 1978, month: 01, day: 14),
        Legs = 2,
    },
};

for (int i = 0; i < animals.Length; i++)
{
    if (animals[i] != null)
    {
        string message = $"Nome: {animals[i].Name} \n";
        message += $"Data de nascimento: {animals[i].BirthDate.ToShortDateString()} ";
        Console.WriteLine(message + "\n");
    }
}
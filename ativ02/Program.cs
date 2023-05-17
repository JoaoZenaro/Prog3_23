using System.Collections.Generic;

var path = new List<string>();

path.Add("Raiz");

string? input, input2;
Console.WriteLine("Bem-vindo, Usuario!");
Thread.Sleep(1000);
do{
    //Console.WriteLine($"{String.Join("/", path.ToArray())} \nSelecione uma opção:");
    menu(new string[] { "1. Cadastros", "2. Relatorios", "0. Sair" });
    input = Console.ReadLine() ?? "";

    switch (input)
    {
        case "1":
            path.Add("Cadastros");
            menu(new string[] { "1. Médicos", "2. Animais", "3. Atendimentos", "4. Sair" });
            input2 = Console.ReadLine();

            switch(input2)
            {
                case "0":
                    break;
                default:
                    break;
            }

            break;
            
        case "2":
            path.Add("Relatorios");
            menu(new string[] { "1. Animais", "2. Atendimentos", "3. Sair" });
            input2 = Console.ReadLine();
            break;
            
        case "0":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Saindo..");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(500);
            break;

        default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Opção Invalida!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(500);
            break;
    }

} while (!input.Equals("0") && !string.IsNullOrEmpty(input));


void menu(string[] arr) {
    Console.Clear();
    Console.WriteLine($"Caminho atual: {String.Join(" > ", path.ToArray())} \n");
    foreach (string i in arr)
    {
        Console.WriteLine(i);
    }
    Console.Write("\nSelecione uma opção: ");
}
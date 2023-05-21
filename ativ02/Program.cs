var path = new List<string>();

path.Add("Raiz");

string? input, input2;
Console.WriteLine("Bem-vindo, Usuario!");
Thread.Sleep(1000);

do
{
    menu(new string[] { "1. Cadastros", "2. Relatórios", "0. Sair" });
    input = Console.ReadLine() ?? "";

    switch (input)
    {
        case "1":
            path.Add("Cadastros");
            do
            {
                menu(new string[] { "1. Médicos", "2. Animais", "3. Atendimentos", "4. Sair" });
                input2 = Console.ReadLine() ?? "";

                switch (input2)
                {
                    case "1":
                        Console.WriteLine("Médicos");
                        pause();
                        break;
                    case "2":
                        Console.WriteLine("Animais");
                        pause();
                        break;
                    case "3":
                        Console.WriteLine("Atendimentos");
                        pause();
                        break;
                }

            } while (input2 != "4" && !string.IsNullOrEmpty(input2));

            path.RemoveAt(path.Count - 1);
            break;

        case "2":
            path.Add("Relatórios");
            do
            {
                menu(new string[] { "1. Animais", "2. Atendimentos", "3. Sair" });
                input2 = Console.ReadLine() ?? "";

                switch (input2)
                {
                    case "1":
                        Console.WriteLine("Animais");
                        pause();
                        break;
                    case "2":
                        Console.WriteLine("Atendimentos");
                        pause();
                        break;
                }

            } while (input2 != "3" && !string.IsNullOrEmpty(input2));

            path.RemoveAt(path.Count - 1);
            break;

        case "0":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Saindo..");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(500);
            break;

        default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Opção Inválida!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(750);
            break;
    }

} while (input != "0" && !string.IsNullOrEmpty(input));

void menu(string[] arr)
{
    Console.Clear();
    Console.WriteLine($"Caminho atual: {String.Join(" > ", path.ToArray())} \n");
    foreach (string i in arr)
    {
        Console.WriteLine(i);
    }
    Console.Write("\nSelecione uma opção: ");
}

void pause()
{
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

using static System.Linq.Enumerable;

Console.Clear();
Console.WriteLine("Calculo fatorial recursivo");
Console.WriteLine(string.Concat(Repeat("*", (int)32)) + "\n");
Console.WriteLine("Digite um numero: ");
int numInput = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Fatorial de {numInput}: {Factorial(numInput)}");
Console.WriteLine($"Fibonacci de {numInput}: {Fibonacci(numInput)}");

static int Factorial(int num)
{
    if (num < 0)
    {
        throw new ArgumentException(
            message: $"A funcao fatorial nao suporta numeros negativos. Input: {num}",
            paramName: nameof(num)
        );
    }
    else if (num == 0) // caso base 2
    {
        return 1;
    }
    else // caso recursivo
    {
        return num * Factorial(num - 1);
    }
}

static long Fibonacci(int num)
{
    if (num <= 2L)
        return 1L;

    return Fibonacci(num - 1) + Fibonacci(num - 2);
}


// using System;

// class ArrowMenu
// {
//     static void Main(string[] args)
//     {
//         Console.CursorVisible = true;
//         int selectedOption = 0;
//         string[] options = { "Option 1", "Option 2", "Option 3", "Option 4" };
//         while (true)
//         {
//             Console.Clear();
//             Console.WriteLine("Select an option:");
//             for (int i = 0; i < options.Length; i++)
//             {
//                 if (i == selectedOption)
//                 {
//                     Console.ForegroundColor = ConsoleColor.Black;
//                     Console.BackgroundColor = ConsoleColor.White;
//                 }
//                 Console.WriteLine(options[i]);
//                 Console.ResetColor();
//             }
//             ConsoleKeyInfo keyInfo = Console.ReadKey();
//             switch (keyInfo.Key)
//             {
//                 case ConsoleKey.UpArrow:
//                     selectedOption = (selectedOption == 0) ? options.Length - 1 : selectedOption - 1;
//                     break;
//                 case ConsoleKey.DownArrow:
//                     selectedOption = (selectedOption == options.Length - 1) ? 0 : selectedOption + 1;
//                     break;
//                 case ConsoleKey.Enter:
//                     Console.Clear();
//                     Console.WriteLine("You selected: " + options[selectedOption]);
//                     Console.ReadLine();
//                     break;
//             }
//         }
//     }
// }
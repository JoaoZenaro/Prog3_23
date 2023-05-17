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


static void PrintMultiplicationMatrixTableRecursive(int rows, int cols, int currentRow = 1, int currentCol = 1)
{
    if (currentRow == 1 && currentCol == 1)
    {
        Console.Write("\t");
        for (int j = 1; j <= cols; j++)
        {
            Console.Write($"{j}\t");
        }
        Console.WriteLine();
    }

    if (currentCol == 1)
    {
        Console.Write($"{currentRow}\t");
    }

    Console.Write($"{currentRow * currentCol}\t");

    if (currentCol < cols)
    {
        PrintMultiplicationMatrixTableRecursive(rows, cols, currentRow, currentCol + 1);
    }
    else if (currentRow < rows)
    {
        Console.WriteLine();
        PrintMultiplicationMatrixTableRecursive(rows, cols, currentRow + 1, 1);
    }

    if (currentRow == rows && currentCol == cols)
    {
        Console.WriteLine();
    }
}
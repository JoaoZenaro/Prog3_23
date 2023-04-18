Console.WriteLine("Digite um numero: ");

try
{
    int input = Convert.ToInt32(Console.ReadLine());
    MultiplicationTable(input);
}
catch (System.Exception)
{
    Console.WriteLine("Entrada invalida");
    throw;
}

// static void MultiplicationTable(int n)
// {
//     for (int i = 1; i <= 10; i++)
//     {
//         Console.WriteLine($"{i,2} x {n,2}  = {i * n,3}");
//     }
// }

// static int MultiplicationTable(int n, int m = 9)
// {
//     if (n <= 0)
//         return 1;

//     Console.WriteLine($"{n} x {m} = {n * m}");

//     return MultiplicationTable(n - 1, m);
// }



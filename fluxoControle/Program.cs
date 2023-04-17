string password = "Samurai";
string retorno = string.Empty;

if (password.Length < 10)
    retorno = "Senha muito curta";
else if (password.Length > 15)
    retorno = "Senha muito longa";
else
    retorno = "Sua senha esta ok";

Console.WriteLine(retorno);


object o = "3";
int j = 4;

if (o is int i)
    Console.WriteLine($"{i} x {j} = {i * j}");
else
    Console.WriteLine("multiplicacao impossivel");

int number = Random.Shared.Next(1, 7);
Console.WriteLine($"Meu numero aleatorio eh: {number}");

switch (number)
{
    case 1:
        Console.WriteLine("Um");
        break;
    case 2:
        Console.WriteLine("Dois");
        break;
    case 3:
    case 4:
        Console.WriteLine("Três ou Quatro");
        goto case 1;
    case 5:
        goto A_label;
    default:
        Console.WriteLine("Default");
        break;
}

Console.WriteLine("Depois do switch");
A_label:
Console.WriteLine("Depois de A_label");
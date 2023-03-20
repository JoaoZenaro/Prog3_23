Console.WriteLine("Ola, bem-vindo!");
Console.WriteLine("Qual eh o seu nome?");
string name = Console.ReadLine();
Console.WriteLine($"Ola, {name}, prazer conhece-lo");

// declarar sem inicializar / primitivo
string message1;

// Declarar inicializar / abstrato
String messege2 = "Seu Nome Completo";

// Declarar String vazia
string message3 = String.Empty;
string message4 = "";

//Declaração com tipo implícito
var message5 = "Mensagem aleatória";

message1 = "Rogerio Ceni;Pele";
var palavras = message1.Split(';');

foreach (var word in palavras)
{
    int a = 10;
    Console.WriteLine(word);
}
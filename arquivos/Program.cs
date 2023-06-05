int option;

do
{
    Console.WriteLine(new String('*', 40));
    Console.WriteLine("Programa para leitura e exportação de dados");
    Console.WriteLine(new String('*', 40));
    Console.WriteLine("1 - Clientes");

    option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("Opção clientes");
            break;
    }

} while (option != 0);
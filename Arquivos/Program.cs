﻿using System;
using Arquivos.Views;

/* programa para leitura e exportação em arquivos .txt */

int option;

do
{
    Utils.BoxPrint("Programa para leitura e exportação de dados");

    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Animais");
    Console.WriteLine("3 - Sair");

    Console.Write("\nOpção: ");

    if(!Int32.TryParse(Console.ReadLine(), out option))
    {
        Console.Write("Opção inválida.\n\u001b[33m<Pressione alguma tecla para continuar>\u001b[0m");
        Console.ReadKey();
    }

    switch (option)
    {
        case 1:
            Utils.BoxPrint("Clientes");
            ClientView clientView = new ClientView();
            break;
        case 2:
            Utils.BoxPrint("Animais");
            AnimalView animalView = new AnimalView();
            break;
        default:
            break;
    }

} while (option != 3);
﻿using System;
using Arquivos.Views;

/* programa para leitura e exportação em arquivos .txt */

int option = 0;

do
{
    Console.WriteLine("*******************");
    Console.WriteLine("Programa para leitura e exportação de dados");
    Console.WriteLine("*******************\n");
    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Animais");

    Console.Write("Opção: ");
    option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("OPÇÃO CLIENTES");
            ClientView clientView = new ClientView();
            break;
        case 2:
            Console.WriteLine("OPÇÃO ANIMAIS");
            AnimalView animalView = new AnimalView();
            break;
        default:
            break;
    }
} while (option > 0);
﻿using System;
using Arquivos.Views;

/* programa para leitura e exportação em arquivos .txt */

bool arrowMenu = false; // true: habilita navegação por setas (up, down) somente menu principal
int option;

do
{
    Utils.BoxPrint("Programa para leitura e exportação de dados");

    var menu = new Menu(new string[] { "1 - Clientes", "2 - Animais", "3 - Sair" });
    menu.Draw();
    
    if (arrowMenu)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            menu.Draw();
            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: menu.MoveUp(); break;
                case ConsoleKey.DownArrow: menu.MoveDown(); break;
            }
        }
        while (keyInfo.Key != ConsoleKey.Enter);

        option = menu.SelectedIndex + 1;
    }
    else
    {
        Console.Write("\nOpção: ");
        Int32.TryParse(Console.ReadLine(), out option);
    }

    switch (option)
    {
        case 1:
            ClientView clientView = new ClientView();
            break;
        case 2:
            AnimalView animalView = new AnimalView();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Saindo...");
            Console.CursorVisible = true;
            break;
        default:
            Console.Write(new string(' ', Console.WindowWidth));
            Console.WriteLine("Opção inválida.");
            Utils.Pause();
            break;
    }

} while (option != 3);
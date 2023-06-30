using System;
using ativ_final.Views;

int option;

do
{
    Utils.BoxPrint("Atividade Final de Clínica Veterinária");

    var menu = new Menu(new string[] { "1 - Animais", "2 - Veterinarios", "3 - Clinicas", "4 - Clientes", "5 - Sair" });
    menu.Draw();

    Console.Write("\nOpção: ");
    Int32.TryParse(Console.ReadLine(), out option);
    
    switch (option)
    {
        case 10: Utils.HiddenImport(); break;
        case 1: AnimalView animalView = new AnimalView(); break;
        case 2: VetView vetView = new VetView(); break;
        case 3: ClinicView clinicView = new ClinicView(); break;
        case 4: ClientView clientView = new ClientView(); break;
        case 5:
            Console.Clear();
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.Write(new string(' ', Console.WindowWidth));
            Console.WriteLine("Opção inválida.");
            Utils.Pause();
            break;
    }

} while (option != 5);
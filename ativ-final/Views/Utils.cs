using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ativ_final.Views
{
    public class Utils
    {
        public static void BoxPrint(string input)
        {
            Console.Clear();
            int width = input.Length + 4;
            Console.WriteLine($"+{new string('-', width)}+");
            Console.WriteLine($"|  {input}  |");
            Console.WriteLine($"+{new string('-', width)}+\n");
        }

        public static void Pause()
        {
            Console.CursorVisible = false;
            Console.Write("\n\u001b[33m<Pressione alguma tecla para continuar>\u001b[0m");
            Console.ReadKey();
            Console.CursorVisible = true;
        }
    }

    public class Menu
    {
        public Menu(IEnumerable<string> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyList<string> Items { get; }

        public void Draw()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine(Items[i]);
            }
        }
    }
}
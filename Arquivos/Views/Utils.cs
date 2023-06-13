using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Views
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
        public int SelectedIndex { get; private set; } = -1;
        public string? SelectedOption => SelectedIndex != -1 ? Items[SelectedIndex] : null;

        public void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 4);
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{(SelectedIndex == i ? $"\u001b[47m{Items[i]}\u001b[0m" : Items[i])}");
            }
            Console.CursorVisible = true;
        }

        public void MoveUp() => SelectedIndex = SelectedIndex == 0 ? Items.Count - 1 : SelectedIndex - 1;
        public void MoveDown() => SelectedIndex = SelectedIndex == Items.Count - 1 ? 0 : SelectedIndex + 1;
    }
}
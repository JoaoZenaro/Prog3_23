public class Menu
{
    public Menu (IEnumerable<string> items)
    {
        Items = items.ToArray ();
    }

    public IReadOnlyList<string> Items { get; }
    public int SelectedIndex { get; private set; } = -1;
    public string? SelectedOption => SelectedIndex != -1 ? Items[SelectedIndex] : null;

    public void Draw()
    {
        Console.CursorVisible = false;
        Console.Clear();

        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{(SelectedIndex == i ? $"\u001b[47m \u00BB {Items[i]} \u00AB \u001b[0m" : "   " + Items[i])}");
        }
    }

    public void MoveUp () => SelectedIndex = SelectedIndex == 0 ? Items.Count - 1 : SelectedIndex - 1;
    public void MoveDown () => SelectedIndex = SelectedIndex == Items.Count - 1 ? 0 : SelectedIndex + 1;
}

internal class Program
{
    public static void Main (string[] args)
    {
        var menu = new Menu(new string[] { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6" });
        Console.OutputEncoding = System.Text.Encoding.UTF8;  
        
        bool done = false;

        do
        {
            menu.Draw();
            var keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: menu.MoveUp (); break;
                case ConsoleKey.DownArrow: menu.MoveDown(); break;
                case ConsoleKey.Enter: done = true; break;
            }
        }
        while (!done);

        Console.CursorVisible = true;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Selected option: " + (menu.SelectedOption ?? "(nothing)"));
        Console.ReadKey();
    }
}
namespace exeConverter
{
    class Program
    {
        public static void Main()
        {
            string? input;
            while (true)
            {
                Console.Write("Digite um numero: ");
                input = Console.ReadLine();

                if (input == string.Empty) { break; }

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Converter.numeroParaExtenso(Convert.ToDecimal(input)));
                    Console.ResetColor();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Numero Invalido!");
                    Console.ResetColor();
                }

            }
        }
    }
}
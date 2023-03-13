class Program
{
    public static void Main()
    {

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine(numeroParaExtenso(i));
        }
    }

    public static string numeroParaExtenso(int num)
    {
        string[] zeroADezenove = new string[]{"zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito",
        "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove", "vinte"};

        switch (num)
        {
            case int i when num > 0 && num < 20:
                return zeroADezenove[num];
            default:
                return "Zero";
        }
    }
}
class Program
{
    public static void Main()
    {

        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(numeroParaExtenso(Convert.ToDecimal(i)));
        }
    }

    public static string numeroParaExtenso(decimal num)
    {
        string res;

        string[] zeroADezenove = new string[]{"zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito",
        "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove"};

        string[] vinteACem = new string[] { "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

        switch (num)
        {
            case decimal i when num > 0 && num < 20:
                return zeroADezenove[Convert.ToInt32(num)];
            case decimal i when num > 20 && num < 100:
                if (num % 10 == 0)
                    res = vinteACem[Convert.ToInt32(num / 10)];

                res = $"{vinteACem[Convert.ToInt32(Math.Floor(num / 10))]} e {zeroADezenove[Convert.ToInt32(num % 10)]}";

                return res;
            default:
                return "Zero";
        }
    }
}
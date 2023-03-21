namespace exeConverter
{
    class Converter
    {
        public static string numeroParaExtenso(decimal num)
        {
            int decInInt = (num % 1 != 0) ? Convert.ToInt32(Convert.ToString(num % 1).Substring(2)) : 0;

            string sufixo = (decInInt > 0 && decInInt < 101) ? (decInInt == 1) ? "Décimo" : "Décimos" : "";

            return (decInInt != 0) ?
                    getInteger(Convert.ToInt32(Math.Truncate(num))) + "com " + getInteger(decInInt) + sufixo
                    : getInteger(Convert.ToInt32(num));
        }

        private static string[] arrUnid = new string[] { "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove" };
        private static string[] arrDez = new string[] { "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa" };
        private static string[] arrCent = new string[] { "Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos" };

        private static string getInteger(int num)
        {
            switch (num)
            {
                case 0:
                    return "Zero";
                case var case1 when 1 <= case1 && case1 <= 19:
                    return arrUnid[num - 1] + " ";
                case var case1 when 20 <= case1 && case1 <= 99:
                    return (num % 10 == 0) ? arrDez[num / 10 - 2] + " " : arrDez[num / 10 - 2] + " e " + getInteger(num % 10);
                case 100:
                    return "Cem ";
                case var case2 when 101 <= case2 && case2 <= 999:
                    return (num % 100 == 0) ? arrCent[num / 100 - 1] + " " : arrCent[num / 100 - 1] + " e " + getInteger(num % 100);
                case var case3 when 1000 <= case3 && case3 <= 1999:
                    switch (num % 1000)
                    {
                        case 0:
                            return "Mil ";
                        case var case4 when case4 <= 100:
                            return "Mil e " + getInteger(num % 1000);
                        default:
                            return "Mil, " + getInteger(num % 1000);
                    }
                case var case5 when 2000 <= case5 && case5 <= 999999:
                    switch (num % 1000)
                    {
                        case 0:
                            return getInteger(num / 1000) + "Mil ";
                        case var case6 when case6 <= 100:
                            return getInteger(num / 1000) + "Mil e " + getInteger(num % 1000);
                        default:
                            return getInteger(num / 1000) + "Mil, " + getInteger(num % 1000);
                    }
                case var case7 when 1000000 <= case7 && case7 <= 1999999:
                    switch (num % 1000000)
                    {
                        case 0:
                            return "Um Milhão";
                        case var case8 when case8 <= 100:
                            return getInteger(num / 1000000) + "Milhão e " + getInteger(num % 1000000);
                        default:
                            return getInteger(num / 1000000) + "Milhão, " + getInteger(num % 1000000);
                    }
                case var case9 when 2000000 <= case9 && case9 <= 999999999:
                    switch (num % 1000000)
                    {
                        case 0:
                            return getInteger(num / 1000000) + "Milhões ";
                        case var case10 when case10 <= 100:
                            return getInteger(num / 1000000) + "Milhões e " + getInteger(num % 1000000);
                        default:
                            return getInteger(num / 1000000) + "Milhões, " + getInteger(num % 1000000);
                    }
                case var case11 when 1000000000 <= case11 && case11 <= 1999999999:
                    switch (num % 1000000000)
                    {
                        case 0:
                            return "Um Bilhão";
                        case var case12 when case12 <= 100:
                            return getInteger(num / 1000000000) + "Bilhão e " + getInteger(num % 1000000000);
                        default:
                            return getInteger(num / 1000000000) + "Bilhão, " + getInteger(num % 1000000000);
                    }
                default:
                    switch (num % 1000000000)
                    {
                        case 0:
                            return getInteger(num / 1000000000) + "Bilhões ";
                        case var case13 when case13 <= 100:
                            return getInteger(num / 1000000000) + "Bilhões e " + getInteger(num % 1000000000);
                        default:
                            return getInteger(num / 1000000000) + "Bilhões, " + getInteger(num % 1000000000);
                    }
            }
        }
    }
}
// Menu de inicialização

string? entrada = string.Empty;

Console.WriteLine("--------------------");
Console.WriteLine("Tratamento de erros");
Console.WriteLine("--------------------");

do
{
    Console.WriteLine("");
    Console.WriteLine("Selecione uma das opções abaixo: ");
    Console.WriteLine("1 - Tratamento de erro");
    Console.WriteLine("2 - Try {} Catch {}");
    Console.WriteLine("3 - Catch com filtros");
    Console.WriteLine("4 - Option 4");
    Console.WriteLine("5 - Option 5");
    Console.WriteLine("0 - Sair");

    entrada = Console.ReadLine() ?? "";

    switch (entrada)
    {
        case "1":
            //int count = int.Parse("abc");
            bool aux = true;

            while (aux)
            {
                Console.WriteLine("Quantos ovos na cesta?");
                string? input1 = Console.ReadLine();

                if (int.TryParse(input1, out int count))
                {
                    Console.WriteLine($"Existem {count} ovos na cesta.");
                    aux = false;
                }
                else
                {
                    Console.WriteLine("Não é um numero valido.");
                    aux = true;
                }
            }

            break;

        case "2":
            Console.WriteLine("Antes da validação");
            Console.WriteLine("Informe sua idade: ");

            string? input2 = Console.ReadLine();
            try
            {
                int age = int.Parse(input2);

                int[] vetinteiro = { 0, 1, 2, 3 };

                Console.WriteLine(vetinteiro[vetinteiro.Length]);
            }
            catch (IndexOutOfRangeException ixorgex)
            {
                Console.WriteLine($"Queridão, não deu. \n {ixorgex.GetType()} : {ixorgex.Message}");
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Erro de formato invalido de dados. \n {fex.GetType()} : {fex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro. Dados invalidos. \n {ex.GetType()} : {ex.Message}");
                throw;
            }
            Console.WriteLine("Depois da validação");
            break;

        case "3":
            Console.WriteLine("Informe o valor: ");
            string? input3 = Console.ReadLine();

            if (string.IsNullOrEmpty(input3))
            {
                Console.WriteLine("Quantia invalida");
            }
            else
            {
                try
                {
                    decimal amountValue = decimal.Parse(input3);
                    Console.WriteLine($"Valor formatado: {amountValue:C}");
                }
                catch (FormatException fex) when (input3.Contains("$"))
                {
                    Console.WriteLine($"O valor deve ser informado sem $. \n {fex.GetType()} : {fex.Message}");
                }
                catch (FormatException fex)
                {
                    Console.WriteLine($"Informe apenas os digitos. \n {fex.GetType()} : {fex.Message}");
                }
            }
            break;

        case "4":
            break;

        case "5":
            break;

        case "0":
            break;

        default:
            Console.WriteLine("Opção Invalida!");
            break;
    }

} while (!entrada.Equals("0") && !string.IsNullOrEmpty(entrada));

while (true)
{

    break;
}
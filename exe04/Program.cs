var myFloat = 10f;
float meuFloat = 11;

// conversao de tipo numerico
int myInteger = 100;
meuFloat = (float)myInteger;
decimal myDecimal = Convert.ToDecimal(myInteger);

var myDouble = 10d;
myDecimal = 10m;

string meuNumeroTexto = Convert.ToString(myInteger);
int qtdChars = meuNumeroTexto.Length;
for (int i = 0; i < qtdChars; i++)
{
    Console.WriteLine(meuNumeroTexto[i]);
}
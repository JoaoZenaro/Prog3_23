//operadores Unários

int x = 5;
int incrementoPos = x++; // 6
incrementoPos++; // 7

x++; x = x + 1; // 6

int incrementoPre = ++x; // 6

Console.WriteLine($"Pos fixado: {incrementoPos}");
Console.WriteLine($"Pre fixado: {incrementoPre}");

// obter tipo de variavel
Type tipoInt = typeof(int);
Type tipoX = x.GetType();

// obter nome de variavel
string nomeVar = nameof(x);
int quantBytes = sizeof(int);

Console.WriteLine(quantBytes);

Console.WriteLine("Nome da var: " + nomeVar);

// operadores de atribuicao
int p = 6;
p += 3; // equivalente a p = p + 3
Console.WriteLine($"+={p}");
p -= 3; // equivalente a p = p - 3
Console.WriteLine($"-={p}");
p *= 3; // equivalente a p = p * 3
Console.WriteLine($"*={p}");
p /= 3; // equivalente a p = p / 3
Console.WriteLine($"/={p}");

// OPERADORES LOGICOS
bool a = true;
bool b = false;

WriteLine($"AND\t|a\t|b\t");
WriteLine($"a\t|{a & a,-5}\t|{a & b,-5}\t");
WriteLine($"b\t|{b & a,-5}\t|{b & b,-5}\t\n");
WriteLine($"OR\t|a\t|b\t");
WriteLine($"a\t|{a | a,-5}\t|{a | b,-5}\t");
WriteLine($"b\t|{b | a,-5}\t|{b | b,-5}\t\n");
WriteLine($"XOR\t|a\t|b\t");
WriteLine($"a\t|{a ^ a,-5}\t|{a ^ b,-5}\t");
WriteLine($"b\t|{b ^ a,-5}\t|{b ^ b,-5}\t\n");
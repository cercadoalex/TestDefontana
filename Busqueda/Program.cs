// See https://aka.ms/new-console-template for more information

int total = 0;

int inicio = 0;
int final = 0;

Console.WriteLine($"ESCRIBIR EL RANGO INICIAL");
inicio = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"ESCRIBIR EL RANGO FINAL");
final = Convert.ToInt32(Console.ReadLine());

if (inicio < final)
{
    for (var index = inicio; index <= final; index++)
    {
        var digitos = (int)Math.Floor(Math.Log10(Math.Abs(index)) + 1);

        if (digitos > 1)
        {
            var negativo_replace = index < 0 ? index.ToString().Replace("-", "") : index.ToString();
            
            var  numero_split = negativo_replace.ToString().Select(digitos => int.Parse(digitos.ToString()));
            
            foreach (int s in numero_split)
            {
                if (s == 1)
                {
                    total++;
                }
            }
        }
        else
        {
            if (index == 1 || index == -1)
            {
                total++;
            }
        }
    }
    Console.WriteLine($"\nSE ENCONTRARON {total} digitosOS DE VALOR (1) ENTRE UN RANGO DE {inicio} AL {final}");
}
else
{
    Console.WriteLine($"EL RANGO {inicio} DEBE SER MAYOR AL RANGO {final}");
}




Console.ReadKey();

using Exercicios_logica_ADA;

int[,] distancias = new int[5, 5];

for (int i = 0; i < 5; i++)
{
  for (int j = 0; j < 5; j++)
  {
    if (i == j)
    {
      distancias[i, j] = 0;
    }
    else if (i > j)
    {
      distancias[i, j] = distancias[j, i];
    }
    else
    {
      Console.WriteLine($"Entre com a distância entre {i + 1} e {j + 1}");
      _ = int.TryParse(Console.ReadLine(), out var distancia);
      distancias[i, j] = distancia;
    }
  }
}

Console.WriteLine("\n");
Utils.ImprimirMatriz(distancias, 5);
Console.ReadLine();

List<int> trajeto = new();
do
{
  Console.WriteLine("Digite a proxima cidade do trajeto desejado (entre com 0 pra finalizar): ");
  bool converteu = int.TryParse(Console.ReadLine(), out int local);

  if (!converteu || local > 5 || local < 1)
  {
    if (local != 0)
      Console.WriteLine("Erro, cidade invalida!");
    else
      break;

    continue;
  }

  trajeto.Add(local);

} while (true);

var percurso = Utils.CalcularPercurso(distancias, trajeto.ToArray());

Console.WriteLine($"\nTrajeto: {string.Join(",",trajeto)}");
Console.WriteLine($"O percurso percorrido foi de {percurso} km.");

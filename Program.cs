using Exercicios_logica_ADA;

namespace Program
{
  public static class Program
  {
    static void Main(string[] args)
    {
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
      Console.WriteLine("\n");

      Console.WriteLine("Entre com o tamanho do trajeto: ");
      _ = int.TryParse(Console.ReadLine(), out int tamanhoTrajeto);

      int[] trajeto = new int[tamanhoTrajeto];
      int contador = 0;
      do
      {
        Console.WriteLine("\nDigite a proxima cidade do trajeto desejado: ");
        bool converteu = int.TryParse(Console.ReadLine(), out int local);

        if (!converteu || local > 5 || local < 1)
        {
          Console.WriteLine("\nErro, cidade invalida!");
          continue;
        }

        trajeto[contador] = local;

        contador++;

      } while (contador < tamanhoTrajeto);

      var percurso = Utils.CalcularPercurso(distancias, trajeto.ToArray());

      Console.WriteLine($"\nTrajeto: {string.Join(",", trajeto)}");
      Console.WriteLine($"O percurso percorrido foi de {percurso} km.");
    }
  }
}

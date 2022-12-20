using Exercicios_logica_ADA;

namespace Program
{
  public static class Program
  {
    static void Main()
    {
      var conteudo = Utils.ReadFileFromDesktop("matriz.txt");
      var tamanho = conteudo.Length;

      int[,] distancias = new int[tamanho, tamanho];

      for (int i = 0; i < tamanho; i++)
      {
        for (int j = 0; j < tamanho; j++)
        {
          var c = conteudo[i].Split(',')[j];
          _ = int.TryParse(c, out distancias[i, j]);
        }
      }

      Utils.ImprimirMatriz(distancias, tamanho);

      var conteudoTrajeto = Utils.ReadFileFromDesktop("caminho.txt")[0].Split(',');
      var tamanhoTrajeto = conteudoTrajeto.Length;

      int [] trajeto = new int[tamanhoTrajeto];
      for (int i = 0; i < tamanhoTrajeto; i++)
      {
        _ = int.TryParse(conteudoTrajeto[i], out var dado);
        trajeto[i] = dado;
      }

      var percurso = Utils.CalcularPercurso(distancias, trajeto);

      Console.WriteLine($"\nTrajeto: {string.Join(",", trajeto)}");
      Console.WriteLine($"O percurso percorrido foi de {percurso} km.");
    }
  }
}

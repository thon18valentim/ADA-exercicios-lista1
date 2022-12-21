using CsvHelper;
using CsvHelper.Configuration;
using Exercicios_logica_ADA;
using System.Globalization;

namespace Program
{
  public static class Program
  {
    static void Main()
    {
      var config = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HasHeaderRecord = false,
      };

      var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      var caminhoArquivo = Path.Combine(caminhoDesktop, "matriz.txt");

      using var reader = new StreamReader(caminhoArquivo);
      using var csv = new CsvParser(reader, config);

      if (!csv.Read())
        return;

      var tamanho = csv.Record.Length;

      int[,] distancias = new int[tamanho, tamanho];

      for (int i = 0; i < tamanho; i++)
      {
        var conteudo = csv.Record;

        for (int j = 0; j < tamanho; j++)
        {
          _ = int.TryParse(conteudo[j], out distancias[i, j]);
        }

        csv.Read();
      }

      Utils.ImprimirMatriz(distancias, tamanho);

      caminhoArquivo = Path.Combine(caminhoDesktop, "caminho.txt");
      using var readerTrajeto = new StreamReader(caminhoArquivo);
      using var csvTrajeto = new CsvParser(readerTrajeto, config);

      if (!csvTrajeto.Read())
        return;

      var tamanhoTrajeto = csvTrajeto.Record.Length;

      int[] trajeto = new int[tamanhoTrajeto];

      var dadosTrajeto = csvTrajeto.Record;
      for (int i = 0; i < dadosTrajeto.Length; i++)
        _ = int.TryParse(dadosTrajeto[i], out trajeto[i]);

      var percurso = Utils.CalcularPercurso(distancias, trajeto);

      Console.WriteLine($"\nTrajeto: {string.Join(",", trajeto)}");
      Console.WriteLine($"O percurso percorrido foi de {percurso} km.");
    }
  }
}


namespace Exercicios_logica_ADA
{
  public static class Utils
  {
    public static void ImprimirMatriz(int [,] matriz, int tamanho)
    {
      for (int i = 0; i < tamanho; i++)
      {
        for (int j = 0; j < tamanho; j++)
        {
          Console.Write(string.Format("{0} ", matriz[i, j]));
        }
        Console.Write(Environment.NewLine + Environment.NewLine);
      }
    }

    public static double CalcularPercurso(int[,] locais, int[] trajeto)
    {
      var percurso = 0;
      for (int i = 0; i < trajeto.Length; i++)
      {
        if (i < trajeto.Length - 1)
          percurso += locais[trajeto[i] - 1, trajeto[i + 1] - 1];
      }

      return percurso;
    }

    public static string[] ReadFileFromDesktop(string nomeArquivo)
    {
      var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      var caminhoArquivo = Path.Combine(caminhoDesktop, nomeArquivo);

      return File.ReadAllLines(caminhoArquivo);
    }
  }
}

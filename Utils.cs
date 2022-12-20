
namespace Exercicios_logica_ADA
{
  public static class Utils
  {
    public static void ImprimirMatriz(int [,] matriz, int size)
    {
      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
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
  }
}

using Exercicios_logica_ADA;

int[,] distancias = new int[5, 5];

var conteudo = Utils.ReadFileFromDesktop("matriz.txt");

for (int i = 0; i < conteudo.Length; i++)
{
  for (int j = 0; j < conteudo.Length; j++)
  {
    var c = conteudo[i].Split(',')[j];
    _ = int.TryParse(c, out distancias[i, j]);
  }
}

Utils.ImprimirMatriz(distancias, conteudo.Length);

conteudo = Utils.ReadFileFromDesktop("caminho.txt")[0].Split(',');

List<int> trajeto = new();
for (int i = 0; i < conteudo.Length; i++)
{
  _ = int.TryParse(conteudo[i], out var dado);
  trajeto.Add(dado);
}

var percurso = Utils.CalcularPercurso(distancias, trajeto.ToArray());

Console.WriteLine($"\nTrajeto: {string.Join(",", trajeto)}");
Console.WriteLine($"O percurso percorrido foi de {percurso} km.");

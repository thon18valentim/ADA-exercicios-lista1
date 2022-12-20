using Exercicios_logica_ADA;

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

conteudo = Utils.ReadFileFromDesktop("caminho.txt")[0].Split(',');

List<int> trajeto = new();
for (int i = 0; i < tamanho; i++)
{
  _ = int.TryParse(conteudo[i], out var dado);
  trajeto.Add(dado);
}

var percurso = Utils.CalcularPercurso(distancias, trajeto.ToArray());

Console.WriteLine($"\nTrajeto: {string.Join(",", trajeto)}");
Console.WriteLine($"O percurso percorrido foi de {percurso} km.");

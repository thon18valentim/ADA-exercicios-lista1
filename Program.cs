using CsvHelper;
using CsvHelper.Configuration;
using Exercicios_logica_ADA;
using System.Globalization;

int[,] distancias = new int[5,5];

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
  HasHeaderRecord = false,
};

var nomeArquivo = "matriz.txt";
var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var caminhoArquivo = Path.Combine(caminhoDesktop, nomeArquivo);

var contador = 0;

using (var reader = new StreamReader(caminhoArquivo))
using (var csv = new CsvParser(reader, config))
{
  while (csv.Read())
  {
    Console.WriteLine(csv.Record);
    contador++;
  }
}

//for (int i = 0; i < conteudo.Length; i++)
//{
//  for (int j = 0; j < conteudo.Length; j++)
//  {
//    var c = conteudo[i].Split(',')[j];
//    _ = int.TryParse(c, out distancias[i, j]);
//  }
//}

//Utils.ImprimirMatriz(distancias, conteudo.Length);

//conteudo = Utils.ReadFileFromDesktop("caminho.txt")[0].Split(',');

//List<int> trajeto = new();
//for (int i = 0; i < conteudo.Length; i++)
//{
//  _ = int.TryParse(conteudo[i], out var dado);
//  trajeto.Add(dado);
//}

//var percurso = Utils.CalcularPercurso(distancias, trajeto.ToArray());

//Console.WriteLine($"\nTrajeto: {string.Join(",", trajeto)}");
//Console.WriteLine($"O percurso percorrido foi de {percurso} km.");

using DesafioAnaliseVendas1.entities;
using System.Globalization;
using System.IO;

namespace DesafioAnaliseVendas1.application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            Console.Write("Entre o caminho do arquivo: ");
            string path = Console.ReadLine();

            // Leitura do arquivo e criação da lista de vendas
            List<Sale> sales = new List<Sale>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] fields = line.Split(',');
                        int month = int.Parse(fields[0]);
                        int year = int.Parse(fields[1]);
                        string seller = fields[2];
                        int items = int.Parse(fields[3]);
                        double total = double.Parse(fields[4]);

                        sales.Add(new Sale(month, year, seller, items, total));
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Erro: {e.Message} (O sistema não pode encontrar o arquivo especificado)");
                return; // Encerra o programa em caso de erro na leitura do arquivo
            }

            // Análise das cinco primeiras vendas de 2016 com maior preço médio
            var topSales2016 = sales
                .Where(s => s.Year == 2016)
                .OrderByDescending(s => s.AveragePrice)
                .Take(5)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Cinco primeiras vendas de 2016 de maior preço médio:");
            foreach (var sale in topSales2016)
            {
                Console.WriteLine(sale);
            }

            // Cálculo do valor total vendido pelo vendedor Logan nos meses 1 e 7
            double totalLogan = sales
                .Where(s => s.Seller == "Logan" && (s.Month == 1 || s.Month == 7))
                .Sum(s => s.Total);

            Console.WriteLine();
            Console.WriteLine($"Valor total vendido pelo vendedor Logan nos meses 1 e 7 = {totalLogan:F2}");
        }
    }
}

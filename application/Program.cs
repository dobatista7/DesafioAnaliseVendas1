using DesafioAnaliseVendas1.entities;
using System.IO;

namespace DesafioAnaliseVendas1.application
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
        }
    }
}

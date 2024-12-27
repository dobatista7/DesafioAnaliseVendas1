using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAnaliseVendas1.entities
{
    internal class Sale
    {

        public int Month { get; set; }
        public int Year { get; set; }
        public string Seller { get; set; }
        public int Items { get; set; }
        public double Total { get; set; }

        public Sale(int month, int year, string seller, int items, double total)
        {
            Month = month;
            Year = year;
            Seller = seller;
            Items = items;
            Total = total;
        }

        public double AveragePrice => Total / Items;

        public override string ToString()
        {
            return $"{Month}/{Year}, {Seller}, items: {Items}, total: {Total:F2}, pm = {AveragePrice:F2}";
        }
    }
}

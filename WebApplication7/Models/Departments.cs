using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departments() { }

        public Departments(int id, string nome )
        {
            Id = id;
  
            Nome = nome;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            //Soma do total de vendas para cada vendedor
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}

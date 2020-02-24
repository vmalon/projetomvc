using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;
using WebApplication7.Models.Enums;

namespace WebApplication7.Data
{
    public class SeedingService 
    {
        private WebApplication7Context _context;

        public SeedingService(WebApplication7Context context)
        {
            _context = context;
        }


        public void Seed()
        {
            //Se existe algum registro
            if(_context.Departments.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //O banco de dados já foi populado
            }

            Departments d1 = new Departments( 1, "Computers" );
            Departments d2 = new Departments( 2, "Eletronics" );
            Departments d3 = new Departments( 3, "Fashion" );
            Departments d4 = new Departments( 4, "Books" );

            Seller s1 = new Seller(1 , "Vinicius", "Vinicius@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2 , "Hiago", "Hiago@gmail.com", new DateTime(2000, 4, 21), 2000.0, d2);
            Seller s3 = new Seller(3 , "Thiago", "Thiago@gmail.com", new DateTime(1990, 4, 21), 1500.0, d3);
            Seller s4 = new Seller(4 , "Lucas", "Lucas@gmail.com", new DateTime(1997, 4, 21), 3500.0, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018,9,25), 11.000,SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2020,9,25), 1.000,SaleStatus.Canceled, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2001,9,25), 900,SaleStatus.Pending, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2002,9,25), 100,SaleStatus.Pending, s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2015,9,25), 3000,SaleStatus.Billed, s2);


            //AddRange, permite adicionar vários objetos de uma vez
            _context.Departments.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1, s2, s3, s4 );
            _context.SalesRecord.AddRange(sr1,sr2,sr3,sr4,sr5);

            _context.SaveChanges();


        }
    }
}

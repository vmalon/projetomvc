using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Services
{
    public class SellerService
    {
        //Retorna uma lista com todos os vendedores

        //Dependencia context
        //ReadOnly, previne alterações
        private readonly WebApplication7Context _context;

        public SellerService(WebApplication7Context context)
        {
            _context = context;
        }


        //Operação síncrona.
        //A aplicação aguarda a operação terminar
        //Assíncronas garante um melhor desempenho
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }






    }
}

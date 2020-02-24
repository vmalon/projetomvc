using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        //SubView para cadastrar o departamento, da view de cadastro Seller
        public ICollection<Departments> Departments { get; set; }

    }
}

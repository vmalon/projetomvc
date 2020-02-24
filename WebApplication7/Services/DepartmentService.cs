using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using WebApplication7.Models;

namespace WebApplication7.Services
{
    public class DepartmentService
    {
        private readonly WebApplication7Context _context;

        public DepartmentService(WebApplication7Context context)
        {
            _context = context;
        }


        public List<Departments> FindAll()
        {
            //Retorna a lista ordenada por nome
            return _context.Departments.OrderBy(x => x.Nome).ToList();
        }


    }
}

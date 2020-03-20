using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Services
{
    public class DepartmentService
    {
        private readonly WebApplication7Context _context;

        public DepartmentService(WebApplication7Context context)
        {
            _context = context;
        }


        public async Task<List<Departments>> FindAllAsync()
        {
            //Retorna a lista ordenada por nome
            //Await informa pro compilador que há um retorno de chamada assincrona
            return await _context.Departments.OrderBy(x => x.Nome).ToListAsync();
        }


    }
}

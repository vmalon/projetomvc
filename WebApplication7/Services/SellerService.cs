using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Services.Exceptions;

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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }


        public Seller FindById(int id)
        {
            //Join das duas tabelas com Entity Framework Core
            return _context.Seller.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            //Any: se existe algum registro com a condição
            //Se não existir um registro igual ao do objeto
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            //A camada de serviço lança a Exceção no seu nível
            //Assim, o controller consegue reconhecer a exceção fora da sua camada
            //Essas exceções de Serviço, são exceções de camada de nível de acesso a dados
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}

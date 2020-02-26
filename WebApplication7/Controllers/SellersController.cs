using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Models.ViewModels;
using WebApplication7.Services;
using WebApplication7.Services.Exceptions;

namespace WebApplication7.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        //Injeção de dependência
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {

            var list = _sellerService.FindAll();

            return View(list);
        }

        //Por padrão, criar GET
        //Altera POST

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        //Recebe um id opcional que pode ser nulo
        public IActionResult Delete(int? id)
        {
            //obj recebe o id, retornado do método FindById, do serviço _sellerSerice
            var obj = _sellerService.FindById(id.Value);

            //Verifica se o id e o obj é nulo e retorna NotFound()
            if (id == null && obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado"});
            }

            //Retorna a View Delete, passando o objeto obj como parâmetro
            return View(obj);
            //id == null && obj == null ? NotFound() : View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            //Verifica se o id e o obj é nulo e retorna NotFound()
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            //obj recebe o id, retornado do método FindById, do serviço _sellerSerice
            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            //Retorna a View Delete, passando o objeto obj como parâmetro
            return View(obj);
            //id == null && obj == null ? NotFound() : View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            //Id a ser atualizado é diferente do Id da URL da requisição
            if (id != seller.Id)
            {
                return BadRequest();
            }

            try
            {
                _sellerService.Update(seller);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        [HttpGet]
        //O id é obrigatório
        //O opcionl é para previnir erros
        public IActionResult Edit(int? id)
        {
            //Verifica se o id e o obj é nulo e retorna NotFound()
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });

            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi encontrado" });
            }

            List<Departments> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);

        }

        public IActionResult Error(string Message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = Message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
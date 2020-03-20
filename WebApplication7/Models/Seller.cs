using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication7.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É obrigatório preencher o nome")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho mínimo do nome é de {2} caracteres.")]
        [Display(Name = "Nome")]
        public string Nme { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Data de Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Range(100.0, 10000000,ErrorMessage = "O salário deve ser entre {1} e {2}")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Departments Department { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set;}
        [Display(Name = "Vendas")]
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string nme, string email, DateTime birthDate, double baseSalary, Departments department)
        {
            Id = id;
            Nme = nme;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Data >= initial && sr.Data <= final).Sum(sr => sr.Amount);
        }
    }
}

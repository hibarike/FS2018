using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Ordered> Ordereds { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Units { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        public Producer Producer { get; set; }
        public ProductType ProductType { get; set; }
        public List<Ordered> Ordereds { get; set; }
    }

    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }

    public class Producer
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Product> Products { get; set; }
    }

    public class Ordered
    {
        public int OrderedId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public DateTime PaymentDAte { get; set; }
        public DateTime ShippingDate { get; set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public List<Ordered> Ordereds { get; set; }
    }

    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Post { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}

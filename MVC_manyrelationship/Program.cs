
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MVC_manyrelationship
{
    class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public List<Store> Total_Products { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public List<Store> Total_Orders { get; set; }
    }

    class Store
    {
        public int StoreID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
    }

    class OrderContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Store> Store { get; set; }

        string connectionstring = "Server=(localdb)\\MSSQLLocalDB; Database=MVC_manyrelationship;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionstring);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
           using(OrderContext context = new OrderContext())
            {
                context.Database.EnsureCreated();

                Product product = new Product { Name = "T-shirt" };
                Order order = new Order { Name = "U12345" };
                Store store = new Store
                {
                    Order = order,
                    Product = product
                        
                };

                context.Products.Add(product);
                context.Orders.Add(order);
                context.Store.Add(store);
                
                context.SaveChanges();

            }
        }
    }
}


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
        public int Price { get; set; }

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

                Product MyProduct1 = new Product();
                MyProduct1.ProductId = 1;
                MyProduct1.Name = "Product 1";
                MyProduct1.Price = 10;

                Product MyProduct2 = new Product();
                MyProduct2.ProductId = 2;
                MyProduct2.Name = "Product 2";
                MyProduct2.Price = 18;

                Order MyOrder1 = new Order();
                MyOrder1.OrderId = 1;
                

                Order MyOrder2 = new Order();
                MyOrder2.OrderId = 2;
                

                Order MyOrder3 = new Order();
                MyOrder3.OrderId = 3;


                context.Products.Add(MyProduct1);
                context.Products.Add(MyProduct2);

                context.Orders.Add(MyOrder1);
                context.Orders.Add(MyOrder2);
                context.Orders.Add(MyOrder3);

                context.SaveChanges();

            }

        }
    }


}

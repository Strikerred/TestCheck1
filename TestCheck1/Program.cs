using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCheck1;

namespace Dev_Test_Nov_2021
{
    //Write your name here
    class Program
    {
        static void Main(string[] args)
        {
            AgeByName.GetDataWithoutAuthentication();

            //Part 2
            List<Product> products = new List<Product> {
                new Product {Id = "B091NE9K3", Price =59.96, Quantity = 5},
                new Product {Id = "B091NEGU3", Price =7.05, Quantity = 10},
                new Product {Id = "B091NEEC3", Price =6.38, Quantity = 15},
                new Product {Id = "B091NE9S3", Price =13.25, Quantity = 23},
                new Product {Id = "B091NE9K4", Price =99.96, Quantity = 2},
                new Product {Id = "B091NEGU4", Price =22.83, Quantity = 150},
                new Product {Id = "B091NEEC4", Price =19.18, Quantity = 45},
                new Product {Id = "B091NE9S4", Price =28.88, Quantity = 345},
                new Product {Id = "B091NE9K5", Price =49.99, Quantity = 589},
                new Product {Id = "B091NEGU5", Price =12.05, Quantity = 25},
            };

            List<Product> lowStock = new List<Product> { };
            Product lowestQuantity = new Product();

            foreach (Product product in products)
            {
                if(product.Quantity < 10)
                {
                    lowStock.Add(product);
                }
            }

            if (lowStock != null)
            {
                Console.WriteLine("Ids low stock");
                foreach (Product product in lowStock)
                {
                    Console.WriteLine(product.Id);
                }
                Console.ReadLine();
            }
            


            //Part 3 
            int[] ordersIds = { 1, 2, 3, 4 };
            double[] ordersValues = { 25.5, 92.5, 78.23, 12.95, 83.67 };
            string[] ordersCustomers = { "Tracy Erkut", "Arvin Aitken", "Ryan Mae", "Sherri Smith", "Adam Weller" };
        }
    }

    class Product
    {
        public string Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
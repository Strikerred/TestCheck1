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
            List<Product> lowStock = new List<Product> { };
            Product lowestQuantity = new Product();
            double averagePrice = 0;
            const double DISCOUNT = 0.70;

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

            foreach (Product product in products)
            {
                if (product.Quantity < 10)
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
                Console.WriteLine("");
            }

            averagePrice = products.Sum(product => product.Price) / products.Count();
            Console.WriteLine($"The average price is {Math.Round(averagePrice, 2)}");
            Console.WriteLine("");

            products.Where(product => product.Id == "B091NE9K4")
                .Select(product => { product.Price = product.Price * DISCOUNT; return product; }).ToList();

            var prod = products.Find(product => product.Id == "B091NE9K4");

            Console.WriteLine($"B091NE9K4 price has been decreased to {Math.Round(prod.Price, 2)}");
            Console.WriteLine("");

            //Part 3 
            int[] ordersIds = { 1, 2, 3, 4 };
            double[] ordersValues = { 25.5, 92.5, 78.23, 12.95, 83.67 };
            string[] ordersCustomers = { "Tracy Erkut", "Arvin Aitken", "Ryan Mae", "Sherri Smith", "Adam Weller" };

            List<Order> orders = new List<Order>();
            var arrays = new[] { ordersIds.Count(), ordersValues.Count(), ordersCustomers.Count() };

            var checkLength = arrays.All(i => i == ordersIds.Length);

            if (checkLength)
            {
                foreach (int pos in ordersIds)
                {
                    addOrder(pos);
                }

            }
            else {
                var maxValue = arrays.Max();
                var minValue = arrays.Min();
                var indexMax = arrays.ToList().IndexOf(maxValue);
                var indexMin = arrays.ToList().IndexOf(minValue);

                var diff = maxValue - minValue;

                while (maxValue != minValue)
                {
                    if (ordersIds.Count() < maxValue)
                    {
                        ordersIds = ordersIds.Concat(new int[] { ordersIds.Count() + 1 }).ToArray();
                    }

                    if (ordersValues.Count() < maxValue)
                    {
                        ordersValues = ordersValues.Append(ordersValues.Count() + 1).ToArray();
                    }

                    if (ordersCustomers.Count() < maxValue)
                    {
                        ordersCustomers = ordersCustomers.Append("AdditionaName" + 1).ToArray();
                    }

                    minValue++;
                }

                foreach (int pos in ordersIds)
                {
                    addOrder(pos);
                }
            }

            void addOrder(int position)
            {
                orders.Add(new Order
                {
                    Id = ordersIds[position-1],
                    OrderValue = ordersValues[position-1],
                    customer = new Customer { FullName = ordersCustomers[position-1] }
                });
            }

            PrintCustomers(orders);

            void PrintCustomers(List<Order> orderList)
            {
                Console.WriteLine("OrderId  OrderValue   Customers");
                var sortedList = orderList.OrderBy(o => o.OrderValue).ToList();
                foreach (Order order in sortedList)
                {
                    Console.WriteLine($"{order.Id,5} {order.OrderValue,10} {order.customer.FullName,17}");
                }
                Console.ReadLine();
            }
        }

        class Product
        {
            public string Id { get; set; }

            public double Price { get; set; }

            public int Quantity { get; set; }
        }

        class Order
        {
            public int Id { get; set; }
            public double OrderValue { get; set; }
            public Customer customer { get; set; }
        }

        class Customer
        {
            public string FullName { get; set; }
        }
    }
}
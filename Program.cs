using ComercialApp.Entities;
using ComercialApp.Entities.Enums;
using System;

namespace ComercialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            byte trava = 1;
            while (trava != 0)
            {
                Console.WriteLine("Enter client data:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Birth date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter order data:");
                Console.Write("Status: ");
                OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
                Console.Write("How many items to this order? ");
                int n = int.Parse( Console.ReadLine());

                Client client = new Client(name, email, date);
                Order order = new Order(status, client);

                for(int i=1; i<=n; i++)
                {
                    Console.WriteLine($"Enter #{i} item data:");
                    Console.Write("Enter product name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    double productPrice = double.Parse(Console.ReadLine());
                    Console.Write("Quantity: ");
                    int productQuantity = int.Parse(Console.ReadLine());
                    Product prod = new Product(productName, productPrice);
                    OrderItem orderItem = new OrderItem(productQuantity, productPrice, prod);
                    order.AddItem(orderItem);
                }

                Console.WriteLine("Order Sumary:");
                Console.WriteLine(order);



                Console.WriteLine("Type 0 to quit..");
                trava = byte.Parse(Console.ReadLine());
                Console.Clear();
            }
        }
    }
}

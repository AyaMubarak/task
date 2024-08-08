using ConsoleApp11.Context;
using ConsoleApp11.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new ShopContext())
        {
           
            var product1 = new Product { Name = "Product A", Price = 100m };
            var product2 = new Product { Name = "Product B", Price = 200m };
            context.Products.AddRange(product1, product2);

            var order1 = new Order { Address = "123 Main St", CreatedAt = DateTime.Now };
            var order2 = new Order { Address = "456 Elm St", CreatedAt = DateTime.Now };
            context.Orders.AddRange(order1, order2);

            context.SaveChanges();

            var products = context.Products.ToList();
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

           
            var orders = context.Orders.ToList();
            Console.WriteLine("\nOrders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id}, Address: {order.Address}, CreatedAt: {order.CreatedAt}");
            }

            
            var productToUpdate = context.Products.First(p => p.Id == 1);
            productToUpdate.Name = "Updated Product A";
            context.SaveChanges();

           
            var orderToUpdate = context.Orders.First(o => o.Id == 1);
            orderToUpdate.CreatedAt = DateTime.Now.AddDays(1);
            context.SaveChanges();

            var productToRemove = context.Products.First(p => p.Id == 2);
            context.Products.Remove(productToRemove);
            context.SaveChanges();

            
            var orderToRemove = context.Orders.FirstOrDefault(o => o.Id == 3);
            if (orderToRemove != null)
            {
                context.Orders.Remove(orderToRemove);
                context.SaveChanges();
            }
        }
    }
}
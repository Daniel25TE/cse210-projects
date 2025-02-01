using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Product product1 = new Product("Soup", 201, 5, 2);
        Product product2 = new Product("Oil", 202, 4, 3);
        Address address = new Address("2773 W Renae", "West Jordan", "UT", "ECU");
        Customer customer= new Customer("Daniel", address);

        Console.WriteLine($"{customer.GetName()} lives in the USA: {customer.LivesInUSA()}");

        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);
        
        Console.WriteLine(order.PackingLabel());
        double totalCost = order.CalculateTotalCost();
        Console.WriteLine($"Total Cost: ${totalCost}");
        Console.WriteLine(order.ShippingLabel());
    }
}
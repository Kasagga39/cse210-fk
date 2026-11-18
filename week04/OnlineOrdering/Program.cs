using System;

class Program
{
    static void Main(string[] args)
    {
        // ============================================
        // Order 1 — Customer in the USA
        // ============================================
        Address address1 = new Address(
            "123 Main Street",
            "Rexburg",
            "ID",
            "USA");

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P100", 25.99, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P101", 89.50, 1));
        order1.AddProduct(new Product("USB-C Cable", "P102", 12.75, 3));

        Console.WriteLine("==========================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("==========================================");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");
        Console.WriteLine();

        // ============================================
        // Order 2 — Customer outside the USA
        // ============================================
        Address address2 = new Address(
            "456 Maple Avenue",
            "Toronto",
            "ON",
            "Canada");

        Customer customer2 = new Customer("Emily Johnson", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Bluetooth Speaker", "P200", 45.00, 1));
        order2.AddProduct(new Product("Phone Case", "P201", 15.50, 2));

        Console.WriteLine("==========================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("==========================================");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
        Console.WriteLine();
    }
}
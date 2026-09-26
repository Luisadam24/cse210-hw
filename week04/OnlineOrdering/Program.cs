using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "110 Patrenda Way Glen View 1",
            "Harare",
            "Harare",
            "Zimbabwe");

        Customer customer1 = new Customer(
            "Mukanya",
            address1);

        Product product1 = new Product(
            "Barcelona Home Jersey",
            "BAR001",
            30.00,
            2);

        Product product2 = new Product(
            "Manchester City Away Jersey",
            "MCI002",
            28.00,
            1);

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);


        Address address2 = new Address(
            "18 Bvunzawabaya Road Old Highfield",
            "Harare",
            "Harare",
            "Zimbabwe");

        Customer customer2 = new Customer(
            "Marlon KO",
            address2);

        Product product3 = new Product(
            "Liverpool Home Jersey",
            "LIV003",
            30.00,
            1);

        Product product4 = new Product(
            "Barcelona Third Jersey",
            "BAR004",
            32.00,
            2);

        Order order2 = new Order(customer2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);


        Console.WriteLine("ORDER 1");
        Console.WriteLine("--------------------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");
        Console.WriteLine();


        Console.WriteLine("ORDER 2");
        Console.WriteLine("--------------------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}
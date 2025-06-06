using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Phone", "P001", 500.0, 2);
            Product product2 = new Product("Laptop", "P002", 1200.0, 1);
            Product product3 = new Product("Book", "P003", 30.0, 3);

            Product product4 = new Product("Car", "P004", 15000.0, 1);
            Product product5 = new Product("Earphone", "P005", 50.0, 4);

            Address address1 = new Address("123 Ikorodu Road", "Lagos", "Lagos", "Nigeria");
            Address address2 = new Address("456 Independence Ave", "Accra", "Greater Accra", "Ghana");
            Address address3 = new Address("789 Elm St", "New York", "NY", "USA");

            Customer customer1 = new Customer("Osaigbovo Henry", address1);
            Customer customer2 = new Customer("Ohenhen Abu", address2);
            Customer customer3 = new Customer("Green Davis", address3);

            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            Order order2 = new Order(customer2);
            order2.AddProduct(product4);
            order2.AddProduct(product5);

            Order order3 = new Order(customer3);
            order3.AddProduct(product1);
            order3.AddProduct(product5);

            Console.WriteLine("ORDER 1");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.GetTotalCost()}");
            Console.WriteLine();

            Console.WriteLine("ORDER 2");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.GetTotalCost()}");
            Console.WriteLine();

            Console.WriteLine("ORDER 3");
            Console.WriteLine(order3.GetPackingLabel());
            Console.WriteLine(order3.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order3.GetTotalCost()}");
        }
    }

    class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetName()
        {
            return name;
        }

        public string GetProductId()
        {
            return productId;
        }
    }

    class Address
    {
        private string street;
        private string city;
        private string state;
        private string country;

        public Address(string street, string city, string state, string country)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
        }

        public bool IsDomestic()
        {
            return country.ToUpper() == "NIGERIA";
        }

        public string GetFullAddress()
        {
            return $"{street}\n{city}, {state}\n{country}";
        }
    }

    class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool IsDomestic()
        {
            return address.IsDomestic();
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }
    }

    class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetTotalCost()
        {
            double total = 0;
            foreach (Product product in products)
            {
                total += product.GetTotalCost();
            }

            if (customer.IsDomestic())
            {
                total += 5.0;
            }
            else
            {
                total += 35.0;
            }

            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in products)
            {
                label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            string label = "Shipping Label:\n";
            label += $"{customer.GetName()}\n";
            label += customer.GetAddress().GetFullAddress();
            return label;
        }
    }
}

using System;
using System.Collections.Generic;


public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    
    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}


public class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    
    public string GetName() => _name;
    public int GetProductId() => _productId;
}


public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    
    public string GetName() => _name;
    public Address GetAddress() => _address;
}


public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public double CalculateTotal()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += CalculateShippingCost();
        return total;
    }

    
    private double CalculateShippingCost()
    {
        return _customer.LivesInUSA() ? 5.0 : 35.0;
    }

    
    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    
    public string ShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address("444 Flower St", "Orange", "CA", "USA");
        Address address2 = new Address("128 Jackson St", "Quebec", "QC", "Canada");

        
        Customer customer1 = new Customer("Jessica Smith", address1);
        Customer customer2 = new Customer("Chris Thomson", address2);

        
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", 101, 999.99, 1));
        order1.AddProduct(new Product("laptop blue protector", 102, 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", 201, 499.99, 1));
        order2.AddProduct(new Product("white Headphones", 202, 199.99, 1));

        
        foreach (var order in new List<Order> { order1, order2 })
        {
            Console.WriteLine(order.PackingLabel());
            Console.WriteLine(order.ShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotal():0.00}\n");
        }
    }
}

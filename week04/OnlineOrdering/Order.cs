using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    // Private member variables (underscoreCamelCase)
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Total price = sum of product costs + one-time shipping
    public double GetTotalPrice()
    {
        double total = 0.0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // One-time shipping cost
        if (_customer.IsInUSA())
        {
            total += 5.0;
        }
        else
        {
            total += 35.0;
        }

        return total;
    }

    // Packing label: name and product id of each product
    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        foreach (Product product in _products)
        {
            label.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }
        return label.ToString();
    }

    // Shipping label: customer name and full address
    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddress().GetFullAddress());
        return label.ToString();
    }
}
using System;

public class Customer
{
    // Private member variables (underscoreCamelCase)
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    // Delegates to Address.IsInUSA()
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}
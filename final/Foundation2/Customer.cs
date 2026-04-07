using System;

public class Customer
{
    public string _customerName;
    public Address _address;

    public Customer(string customerName, Address address)
    {
        _customerName = customerName;
        _address = address;
    }

    public double GetShippingCost()
    {
        double shippingCost;

        if (_address.GetCountry() == "USA")
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }

        return shippingCost;
    }

    public void DisplayCustomer()
    {
        Console.WriteLine($"{_customerName}\r\n{_address.GetAddress()}");
    }
}
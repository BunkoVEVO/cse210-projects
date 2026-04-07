using System;

public class Address
{
    public string _streetAddress;
    public string _city;
    public string _state;
    public string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public void SetCountry(string country)
    {
        _country = country;
    }

    public string GetCountry()
    {
        return _country;
    }

    public string GetAddress() 
    {
        return $"{_streetAddress}\r\n{_city}, {_state}\r\n{_country}";
    }
}
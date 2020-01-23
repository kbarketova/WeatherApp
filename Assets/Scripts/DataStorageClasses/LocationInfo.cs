using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInfo
{
    private readonly string  _country;
    private readonly string  _countryCode;
    private readonly string  _city;
    private readonly float  _latitude;
    private readonly float  _longtitude;
    private readonly string  _timezone;

    public LocationInfo()
    {
        // An error occured while uploading data from openservice
    }

    public LocationInfo(string country, string countryCode, string city, float latitude, float longtitude, string timezone)
    {
        _country = country;
        _countryCode = countryCode;
        _city = city;
        _latitude = latitude;
        _longtitude = longtitude;
        _timezone = timezone;
    }

    public string Country
    {
        get { return _country; }
    }

    public string CountryCode
    {
        get { return _countryCode; }
    }

    public string City
    {
        get { return _city; }
    }

    public float Latitude
    {
        get { return _latitude; }
    }

    public float Longtitude
    {
        get { return _longtitude; }
    }

    public string Timezone
    {
        get { return _timezone; }
    }
}

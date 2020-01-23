using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherInfo
{
    private readonly string _city;           
    private readonly float _clouds;           
    private readonly int _temperature;
    private readonly int _feelsLikeTemperature;
    private readonly float _humidity;
    private readonly float _windSpeed;
    private readonly string _description;

    public WeatherInfo()
    {
        // An error occured while uploading data from openservice
    }

    public WeatherInfo(float clouds)
    {
        _clouds = clouds;
    }

    public WeatherInfo(string city, float clouds, int currentTemperature, int feelsLikeTemperature, float humidity, float windSpeed, string weatherDescription)
    {
        _city = city;
        _clouds = clouds;
        _temperature = currentTemperature;
        _feelsLikeTemperature = feelsLikeTemperature;
        _humidity = humidity;
        _windSpeed = windSpeed;
        _description = weatherDescription;
    }

    public string City
    {
        get { return _city; }
    }

    public float Clouds
    {
        get { return _clouds; }
    }

    public int Temperature
    {
        get { return _temperature; }
    }

    public int FeelsLikeTemperature
    {
        get { return _feelsLikeTemperature; }
    }

    public float Humidity
    {
        get { return _humidity; }
    }

    public float WindSpeed
    {
        get { return _windSpeed; }
    }

    public string Description
    {
        get { return _description; }
    }
}

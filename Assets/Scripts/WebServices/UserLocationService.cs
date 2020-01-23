using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UserLocationService
{
    private readonly INetworkService _networkService;
    private readonly string _url;
    private readonly string _ip;

    private UserLocationService()
    {
        // не даем воможности создать конструктор, не содержащий аргументов, объявив его private
    }

    public UserLocationService(string IPAdress, INetworkService service)
    {
        _ip = IPAdress;
        _url = $"http://ip-api.com/json/{_ip}";
        _networkService = service;
    }

    public async Task<LocationInfo> GetLocation()
    {
        var text = await _networkService.GetAsync(_url);
        Debug.Log("Location info: " + text);

        var location = OnJSONLoaded(text);   // JsonConvert.DeserializeObject<Location>(text);       // Forecast - Json contract

        if (location != null)
        {
            Debug.Log("Location request status: " + location.status);
            return new LocationInfo(
                  location.country,
                  location.countryCode,
                  location.city,
                  location.lat,
                  location.lon,
                  location.timezone
                );
        }

        return new LocationInfo();
    }

    private Location OnJSONLoaded(string data)
    {
        return JsonConvert.DeserializeObject<Location>(data);
    }
}

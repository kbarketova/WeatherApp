using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;


public class OpenWeatherService : IForecastManager
{
    private readonly string _openWeatherKey;
    private readonly string _language;                                    // можно настраивать, если подключить опцию локализации (lang=ru сейчас)

    private readonly INetworkService _networkService;

    private OpenWeatherService()
    {
        // не даем воможности создать конструктор, не содержащий аргументов, объявив его private
    }

    public OpenWeatherService(INetworkService service, string countryCode)
    {
        _openWeatherKey = "5b4644a9b439f82f38796c3a2c242735";
        _networkService = service;
        _language = countryCode.ToLower();

        Debug.Log("Language code " + _language);
    }

    public async Task<WeatherInfo> GetForecastAsync(double lat, double lon)
    {
         var text = await _networkService.GetAsync($"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&lang={_language}&APPID={_openWeatherKey}");
        Debug.Log("Weather info: " + text);

        var forecast = OnJSONLoaded(text);   

        if (forecast != null)
        {
            return new WeatherInfo(
                forecast.name,
                forecast.clouds.all / 100,
                (int)Math.Round(forecast.main.temp),
                (int)Math.Round(forecast.main.feels_like),
                forecast.main.humidity,
                forecast.wind.speed,
                forecast.weather[0].description
                );
        }

        return new WeatherInfo();
    }

    private Forecast OnJSONLoaded(string data)
    {
        return JsonConvert.DeserializeObject<Forecast>(data);  // Forecast - Json contract
    }
}

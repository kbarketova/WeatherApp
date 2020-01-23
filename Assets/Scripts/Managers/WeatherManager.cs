using UnityEngine;
using System.Threading.Tasks;

public class WeatherManager : MonoBehaviour
{
    public static WeatherInfo Forecast;

    private INetworkService _network;

    private async void Awake()
    {
        //  _network = new DummyNetworkService();     
        _network = new NetworkService();      

        await MakeForecastRequestAsync();                 
    }

    public async Task<string> GetUserIPAsync()
    {
        var ipIdentifyigService = new IpIdentifyingService(_network);

        return await ipIdentifyigService.GetIP();
    }

    public async Task<LocationInfo> GetUserLocationAsync()
    {
        var userIP = await GetUserIPAsync();
        Debug.Log("My ip is: " + userIP);

        var locationService = new UserLocationService(userIP, _network);
        return await locationService.GetLocation();
    }

    public async Task MakeForecastRequestAsync()  //INetworkService service
    {
        var userLocation = await GetUserLocationAsync();
        var forecastManager = new OpenWeatherService(_network, userLocation.CountryCode);

        Forecast = await forecastManager.GetForecastAsync(userLocation.Latitude, userLocation.Longtitude);

        EventManager.Instance.PostNotification(EVENT_TYPE.WEATHER_UPDATED, this);
    }
}

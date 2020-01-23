using System.Threading.Tasks;

public interface IForecastManager
{
    Task<WeatherInfo> GetForecastAsync(double lat, double lon);
}

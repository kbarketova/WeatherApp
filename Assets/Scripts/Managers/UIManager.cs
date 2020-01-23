using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Main Panel")]
    [SerializeField]
    private WeatherPanelHeadliners _headliners;

    [SerializeField]
    private MeasureUnits _measureUnits;

    [Header("Main Panel")]
    [SerializeField]
    private Text _location;

    [SerializeField]
    private Text _currentTemperature;

    [SerializeField]
    private Text _weatherDescription;

    [Header("Detailed Panel")]
    [SerializeField]
    private Text _date;

    [SerializeField]
    private Text _feelsLikeTemperature;

    [SerializeField]
    private Text _cloudCover;

    [SerializeField]
    private Text _humidity;

    [SerializeField]
    private Text _windSpeed;

    private void Start()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.WEATHER_UPDATED, UpdateWeatherPanel);
    }

    private void UpdateWeatherPanel(EVENT_TYPE eventType, Component sender, object param = null)
    {
        _location.text = $"{_headliners.location} {WeatherManager.Forecast.City}";
        _currentTemperature.text = $"{WeatherManager.Forecast.Temperature} {_measureUnits.temperature}";
        _weatherDescription.text = WeatherManager.Forecast.Description;

        _date.text = _headliners.date;
        _cloudCover.text = $"{_headliners.cloudCover} {WeatherManager.Forecast.Clouds * 100} {_measureUnits.cloudCover}";
        _feelsLikeTemperature.text = $"{_headliners.feelsLikeTemperature} {WeatherManager.Forecast.FeelsLikeTemperature} {_measureUnits.temperature}";
        _humidity.text = $"{_headliners.humidity} {WeatherManager.Forecast.Humidity} {_measureUnits.humidity}";
        _windSpeed.text = $"{_headliners.windSpeed} {WeatherManager.Forecast.WindSpeed} {_measureUnits.windSpeed}";
    }

}

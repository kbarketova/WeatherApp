using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Headliners", menuName = "WeatherPanelHeadliners")]
public class WeatherPanelHeadliners : ScriptableObject
{
    public string date;
    public string location;
    public string feelsLikeTemperature;
    public string cloudCover;
    public string windSpeed;
    public string humidity;
}

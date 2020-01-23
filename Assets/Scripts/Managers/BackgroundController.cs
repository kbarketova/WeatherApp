using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private Material _sky;

    [SerializeField]
    private Light _sun;

    private float _fullIntensity;

    private void Start()
    {
        _fullIntensity = _sun.intensity;

        EventManager.Instance.AddListener(EVENT_TYPE.WEATHER_UPDATED, OnWeatherUpdated);
    }

    private void OnWeatherUpdated(EVENT_TYPE eventType, Component sender, object param = null)
    {
        SetOvercast(WeatherManager.Forecast.Clouds);
    }

    private void SetOvercast(float value)
    {
        _sky.SetFloat("_Blend", value);

        if (_sun != null)
        {
            _sun.intensity = _fullIntensity - (_fullIntensity * value);
        }
    }

    private void OnDestroy()
    {
        SetOvercast(0);
    }
}

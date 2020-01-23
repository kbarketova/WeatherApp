using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New MeasureUnits", menuName = "Units of Measure")]
public class MeasureUnits : ScriptableObject
{
    public string temperature;
    public string cloudCover;
    public string humidity;
    public string windSpeed;
}

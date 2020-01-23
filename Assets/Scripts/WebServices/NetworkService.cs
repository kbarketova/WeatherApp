using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;


public class DummyNetworkService : INetworkService
{
    public async Task<string> GetAsync(string url)
    {
        await TimeSpan.FromSeconds(1);             
        return "{\"coord\":{\"lon\":39.62,\"lat\":47.21},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"base\":\"stations\",\"main\":{\"temp\":274.15,\"feels_like\":269.91,\"temp_min\":274.15,\"temp_max\":274.15,\"pressure\":1023,\"humidity\":86},\"visibility\":10000,\"wind\":{\"speed\":3,\"deg\":150},\"clouds\":{\"all\":97},\"dt\":1578072260,\"sys\":{\"type\":1,\"id\":8971,\"country\":\"RU\",\"sunrise\":1578028085,\"sunset\":1578058975},\"timezone\":10800,\"id\":541724,\"name\":\"Krasnyy Gorod Sad\",\"cod\":200}";
    }
}

public class NetworkService : INetworkService
{

    public async Task<string> GetAsync(string url)
    {
        using (var request = new UnityWebRequest(url))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            await request.SendWebRequest();

            if (!request.isNetworkError)
            {
                return request.downloadHandler.text;
            }

            return null;
        }
    }
}




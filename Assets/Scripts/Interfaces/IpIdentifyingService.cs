using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IpIdentifyingService
{
    private readonly INetworkService _networkService;
    private readonly string _url;

    private IpIdentifyingService()
    {
        // не даем воможности создать конструктор, не содержащий аргументов, объявив его private
    }

    public IpIdentifyingService(INetworkService service)
    {
        _url = "http://bot.whatismyipaddress.com";
        _networkService = service;
    }

    public async Task<string> GetIP()
    {
        var userIP = await _networkService.GetAsync(_url);

        return userIP;
    }
      
}

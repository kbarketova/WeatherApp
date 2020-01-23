using System.Threading.Tasks;

public interface INetworkService
{
    Task<string> GetAsync(string url);
}

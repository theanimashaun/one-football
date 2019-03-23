using System.Net.Http;

namespace one_football.Services
{
    public interface IBaseService
    {
        HttpClient SetupHttpClient(string baseUrl);
    }
}
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Tests.Api
{
    public interface ITestHost
    {
        Task<HttpClient> GetClientAsync();
        Task<TestServer> GetServerAsync();
    }
}
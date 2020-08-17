using System.Net.Http;

namespace AgrixemMobile
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
